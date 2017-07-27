////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
	public sealed partial class ModelActor
	{
	    private MeshInfo[] _meshes;

	    /// <summary>
	    /// Gets the model mesh infos collection. Each <see cref="MeshInfo"/> contains data how to render each mesh (transformation, material, shadows casting, etc.).
	    /// </summary>
	    /// <value>
	    /// The mesh infos array. It's null if the <see cref="Model"/> property is null or asset is not loaded yet.
	    /// </value>
	    [MemberCollection(CanReorderItems = false, NotNullItems = true, ReadOnly = true)]
	    [EditorIndex(100)]
	    public MeshInfo[] Meshes
	    {
	        get
	        {
	            // Check if has cached data
	            if (_meshes != null)
	                return _meshes;

	            // Cache data
	            var model = Model;
	            if (model && model.IsLoaded)
	            {
	                var meshesCount = model.LODs[0].Meshes.Length;
	                _meshes = new MeshInfo[meshesCount];
	                for (int i = 0; i < meshesCount; i++)
	                {
	                    _meshes[i] = new MeshInfo(this, i);
	                }
	            }

	            return _meshes;
	        }
	    }

	    internal void Internal_OnModelChanged()
	    {
            // Clear cached data
	        _meshes = null;
	    }

#if !UNIT_TEST_COMPILANT
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern void Internal_GetMeshTransform(IntPtr obj, int index, out Transform result);
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern void Internal_SetMeshTransform(IntPtr obj, int index, ref Transform value);
        [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern MaterialBase Internal_GetMeshMaterial(IntPtr obj, int index);
	    [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetMeshMaterial(IntPtr obj, int index, IntPtr value);
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern float Internal_GetMeshScaleInLightmap(IntPtr obj, int index);
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern void Internal_SetMeshScaleInLightmap(IntPtr obj, int index, float value);
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern bool Internal_GetMeshVisible(IntPtr obj, int index);
	    [MethodImpl(MethodImplOptions.InternalCall)]
	    internal static extern void Internal_SetMeshVisible(IntPtr obj, int index, bool value);
#endif
    }
}
