//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Party.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posts
    {
        public int PostID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> PrivacyID { get; set; }
        public string UploadDate { get; set; }
        public Nullable<int> Like { get; set; }
        public Nullable<int> ImageID { get; set; }
        public Nullable<int> CommunityID { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual Communities Communities { get; set; }
        public virtual Images Images { get; set; }
        public virtual Posts Posts1 { get; set; }
        public virtual Posts Posts2 { get; set; }
        public virtual PrivacyStatement PrivacyStatement { get; set; }
        public virtual Users Users { get; set; }
    }
}
