//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pki.eBusiness.ErpApi.Entities.Settings
{
    /// <summary>
    /// The ERPRestSettings Configuration Section.
    /// </summary>
    public partial class ERPRestSettings : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the ERPRestSettings Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string ERPRestSettingsSectionName = "eRPRestSettings";
        
        /// <summary>
        /// The XML path of the ERPRestSettings Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string ERPRestSettingsSectionPath = "eRPRestSettings";
        
        /// <summary>
        /// Gets the ERPRestSettings instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public static global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings Instance
        {
            get
            {
                return ((global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings)(global::System.Configuration.ConfigurationManager.GetSection(global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ERPRestSettingsSectionPath)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region ApiKey Property
        /// <summary>
        /// The XML name of the <see cref="ApiKey"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string ApiKeyPropertyName = "apiKey";
        
        /// <summary>
        /// Gets or sets the ApiKey.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The ApiKey.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ApiKeyPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string ApiKey
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ApiKeyPropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ApiKeyPropertyName] = value;
            }
        }
        #endregion
        
        #region BaseUrl Property
        /// <summary>
        /// The XML name of the <see cref="BaseUrl"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string BaseUrlPropertyName = "baseUrl";
        
        /// <summary>
        /// Gets or sets the BaseUrl.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The BaseUrl.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.BaseUrlPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string BaseUrl
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.BaseUrlPropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.BaseUrlPropertyName] = value;
            }
        }
        #endregion
        
        #region Resources Property
        /// <summary>
        /// The XML name of the <see cref="Resources"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string ResourcesPropertyName = "resources";
        
        /// <summary>
        /// Gets or sets the Resources.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The Resources.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ResourcesPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Pki.eBusiness.ErpApi.Entities.Settings.Resources Resources
        {
            get
            {
                return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resources)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ResourcesPropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.ERPRestSettings.ResourcesPropertyName] = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// The Resource Configuration Element.
    /// </summary>
    public partial class Resource : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=true)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.NamePropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Path Property
        /// <summary>
        /// The XML name of the <see cref="Path"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string PathPropertyName = "path";
        
        /// <summary>
        /// Gets or sets the Path.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The Path.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.PathPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Path
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.PathPropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.PathPropertyName] = value;
            }
        }
        #endregion
        
        #region Method Property
        /// <summary>
        /// The XML name of the <see cref="Method"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string MethodPropertyName = "method";
        
        /// <summary>
        /// Gets or sets the Method.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        [global::System.ComponentModel.DescriptionAttribute("The Method.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.MethodPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Method
        {
            get
            {
                return ((string)(base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.MethodPropertyName]));
            }
            set
            {
                base[global::Pki.eBusiness.ErpApi.Entities.Settings.Resource.MethodPropertyName] = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// A collection of Resource instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMap, AddItemName=global::Pki.eBusiness.ErpApi.Entities.Settings.Resources.ResourcePropertyName)]
    public partial class Resources : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        internal const string ResourcePropertyName = "resource";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMap;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        protected override string ElementName
        {
            get
            {
                return global::Pki.eBusiness.ErpApi.Entities.Settings.Resources.ResourcePropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Pki.eBusiness.ErpApi.Entities.Settings.Resources.ResourcePropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resource)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Pki.eBusiness.ErpApi.Entities.Settings.Resource();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public global::Pki.eBusiness.ErpApi.Entities.Settings.Resource this[int index]
        {
            get
            {
                return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resource)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public global::Pki.eBusiness.ErpApi.Entities.Settings.Resource this[object name]
        {
            get
            {
                return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resource)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="resource">The <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public void Add(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource resource)
        {
            base.BaseAdd(resource);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="resource">The <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public void Remove(global::Pki.eBusiness.ErpApi.Entities.Settings.Resource resource)
        {
            base.BaseRemove(this.GetElementKey(resource));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public global::Pki.eBusiness.ErpApi.Entities.Settings.Resource GetItemAt(int index)
        {
            return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resource)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::Pki.eBusiness.ErpApi.Entities.Settings.Resource"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public global::Pki.eBusiness.ErpApi.Entities.Settings.Resource GetItemByKey(string name)
        {
            return ((global::Pki.eBusiness.ErpApi.Entities.Settings.Resource)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.801")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}