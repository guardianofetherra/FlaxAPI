////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEditor.Modules;
using FlaxEditor.Viewport.Previews;
using FlaxEditor.Windows;
using FlaxEditor.Windows.Assets;
using FlaxEngine;
using FlaxEngine.GUI;
using FlaxEngine.Rendering;

namespace FlaxEditor.Content
{
    /// <summary>
    /// A <see cref="CubeTexture"/> asset proxy object.
    /// </summary>
    /// <seealso cref="FlaxEditor.Content.BinaryAssetProxy" />
    public class CubeTextureProxy : BinaryAssetProxy
    {
        private CubeTexturePreview _preview;

        /// <inheritdoc />
        public override string Name => "Cube Texture";

        /// <inheritdoc />
        public override bool AcceptsTypeID(int typeID)
        {
            return typeID == CubeTexture.TypeID;
        }

        /// <inheritdoc />
        public override EditorWindow Open(Editor editor, ContentItem item)
        {
            return new CubeTextureWindow(editor, item as AssetItem);
        }

        /// <inheritdoc />
        public override Color AccentColor => Color.FromRGB(0x3498db);

        /// <inheritdoc />
        public override ContentDomain Domain => CubeTexture.Domain;

        /// <inheritdoc />
        public override void OnThumbnailDrawPrepare(ThumbnailRequest request)
        {
            if (_preview == null)
            {
                _preview = new CubeTexturePreview(false);
                _preview.RenderOnlyWithWindow = false;
                _preview.Task.Enabled = false;
                _preview.Size = new Vector2(PreviewsCache.AssetIconSize, PreviewsCache.AssetIconSize);
                _preview.Resize();
            }
        }

        /// <inheritdoc />
        public override bool CanDrawThumbnail(ThumbnailRequest request)
        {
            return _preview.HasLoadedAssets;
        }

        /// <inheritdoc />
        public override void OnThumbnailDrawBegin(ThumbnailRequest request, ContainerControl guiRoot, GPUContext context)
        {
            _preview.CubeTexture = (CubeTexture)request.Asset;
            _preview.Parent = guiRoot;

            _preview.Task.Internal_Render(context);
        }

        /// <inheritdoc />
        public override void OnThumbnailDrawEnd(ThumbnailRequest request, ContainerControl guiRoot)
        {
            _preview.CubeTexture = null;
            _preview.Parent = null;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            if (_preview != null)
            {
                _preview.Dispose();
                _preview = null;
            }

            base.Dispose();
        }
    }
}
