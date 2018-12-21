// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using FlaxEditor.Content;
using FlaxEditor.CustomEditors;
using FlaxEditor.GUI;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Tools.Foliage
{
    /// <summary>
    /// Foliage types editor tab. Allows to add, remove or modify foliage instance types defined for the current foliage object.
    /// </summary>
    /// <seealso cref="FlaxEditor.GUI.Tab" />
    public class FoliageTypesTab : Tab
    {
        /// <summary>
        /// The object for foliage type settings adjusting via Custom Editor.
        /// </summary>
        private sealed class ProxyObject
        {
            /// <summary>
            /// The tab.
            /// </summary>
            [HideInEditor]
            public readonly FoliageTypesTab Tab;

            /// <summary>
            /// The foliage actor.
            /// </summary>
            [HideInEditor]
            public FlaxEngine.Foliage Foliage;

            /// <summary>
            /// The selected foliage instance type index.
            /// </summary>
            [HideInEditor]
            public int SelectedFoliageTypeIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProxyObject"/> class.
            /// </summary>
            /// <param name="tab">The tab.</param>
            public ProxyObject(FoliageTypesTab tab)
            {
                Tab = tab;
                SelectedFoliageTypeIndex = -1;
            }

            public Model Model
            {
                get => FoliageTools.GetFoliageTypeModel(Foliage, SelectedFoliageTypeIndex);
                set
                {
                    FoliageTools.SetFoliageTypeModel(Foliage, SelectedFoliageTypeIndex, value);
                    Tab.UpdateFoliageTypesList();
                }
            }
        }

        private readonly ProxyObject _proxy;
        private readonly VerticalPanel _items;
        private readonly Button _addFoliageTypeButton;
        private readonly CustomEditorPresenter _presenter;

        /// <summary>
        /// The parent foliage types tab.
        /// </summary>
        public readonly FoliageTab FoliageTypes;

        /// <summary>
        /// Gets or sets the index of the selected foliage type.
        /// </summary>
        public int SelectedFoliageTypeIndex
        {
            get => _proxy.SelectedFoliageTypeIndex;
            set
            {
                var prev = _proxy.SelectedFoliageTypeIndex;
                if (value == prev)
                    return;

                if (prev != -1)
                {
                    _items.Children[prev].BackgroundColor = Color.Transparent;
                }

                _proxy.SelectedFoliageTypeIndex = value;

                if (value != -1)
                {
                    _items.Children[value].BackgroundColor = Style.Current.BackgroundSelected;

                    _presenter.Select(_proxy);
                    _presenter.BuildLayoutOnUpdate();
                }
                else
                {
                    _presenter.Deselect();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoliageTypesTab"/> class.
        /// </summary>
        /// <param name="tab">The parent tab.</param>
        public FoliageTypesTab(FoliageTab tab)
        : base("Foliage Types")
        {
            FoliageTypes = tab;
            FoliageTypes.SelectedFoliageChanged += OnSelectedFoliageChanged;
            _proxy = new ProxyObject(this);

            // Main panel
            var splitPanel = new SplitPanel(Orientation.Vertical, ScrollBars.Vertical, ScrollBars.Vertical)
            {
                SplitterValue = 0.2f,
                DockStyle = DockStyle.Fill,
                Parent = this
            };

            // Foliage types list
            _items = new VerticalPanel
            {
                Y = 4,
                Height = 4,
                DockStyle = DockStyle.Top,
                IsScrollable = true,
                Parent = splitPanel.Panel1
            };

            // Foliage add button
            _addFoliageTypeButton = new Button
            {
                Text = "Add Foliage Type",
                TooltipText = "Add new model to use it as a new foliage type for instancing and spawning in the level",
                Parent = splitPanel.Panel1
            };
            _addFoliageTypeButton.Clicked += OnAddFoliageTypeButtonClicked;

            // Options editor
            // TODO: use editor undo for changing foliage type options
            var editor = new CustomEditorPresenter(null, "No foliage type selected");
            editor.Panel.Parent = splitPanel.Panel2;
            _presenter = editor;
        }

        private void OnSelectedFoliageChanged()
        {
            _proxy.SelectedFoliageTypeIndex = -1;
            _proxy.Foliage = FoliageTypes.SelectedFoliage;

            _presenter.Deselect();

            UpdateFoliageTypesList();
        }

        private void OnAddFoliageTypeButtonClicked()
        {
            // Show model picker
            AssetSearchPopup.Show(_addFoliageTypeButton, new Vector2(_addFoliageTypeButton.Width * 0.5f, _addFoliageTypeButton.Height), IsItemValidForFoliageModel, OnItemSelectedForFoliageModel);
        }

        private void OnItemSelectedForFoliageModel(AssetItem item)
        {
            var foliage = FoliageTypes.SelectedFoliage;
            var model = FlaxEngine.Content.LoadAsync<Model>(item.ID);

            FoliageTools.AddFoliageType(foliage, model);

            UpdateFoliageTypesList();

            SelectedFoliageTypeIndex = FoliageTools.GetFoliageTypesCount(foliage) - 1;
        }

        private bool IsItemValidForFoliageModel(AssetItem item)
        {
            return item is BinaryAssetItem binaryItem && binaryItem.Type == typeof(Model);
        }

        private void UpdateFoliageTypesList()
        {
            var foliage = FoliageTypes.SelectedFoliage;

            // Cleanup previous items
            _items.DisposeChildren();

            // Add new ones
            float y = 0;
            if (foliage != null)
            {
                int typesCount = FoliageTools.GetFoliageTypesCount(foliage);
                for (int i = 0; i < typesCount; i++)
                {
                    var model = FoliageTools.GetFoliageTypeModel(foliage, i);
                    var asset = FoliageTypes.Editor.ContentDatabase.FindAsset(model.ID);
                    var itemView = new AssetSearchPopup.AssetItemView(asset)
                    {
                        TooltipText = asset.NamePath,
                        Tag = i,
                        Parent = _items,
                    };
                    itemView.Clicked += OnFoliageTypeListItemClicked;

                    y += itemView.Height + _items.Spacing;
                }
                y += _items.Margin.Height;
            }
            _items.Height = y;

            var selectedFoliageTypeIndex = SelectedFoliageTypeIndex;
            if (selectedFoliageTypeIndex != -1)
            {
                _items.Children[selectedFoliageTypeIndex].BackgroundColor = Style.Current.BackgroundSelected;
            }

            // Button
            _addFoliageTypeButton.Location = new Vector2((_addFoliageTypeButton.Parent.Width - _addFoliageTypeButton.Width) * 0.5f, _items.Bottom + 4);
        }

        private void OnFoliageTypeListItemClicked(ItemsListContextMenu.Item item)
        {
            SelectedFoliageTypeIndex = (int)item.Tag;
        }
    }
}
