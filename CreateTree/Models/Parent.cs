//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreateTree.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Parent
    {
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public string parentNodeId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> StartDate { get; set; }
    }
}
