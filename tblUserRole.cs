//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Authentication_OWIN_JWT_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserRole
    {
        public int UserRoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int RoleId { get; set; }
    
        public virtual tblRole tblRole { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
