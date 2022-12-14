//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindYourJob.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Educations = new HashSet<Education>();
            this.JobApplies = new HashSet<JobApply>();
            this.Languages = new HashSet<Language>();
            this.Skills = new HashSet<Skill>();
            this.WorkExperiences = new HashSet<WorkExperience>();
        }
    
        public int EmployeeID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> JobCategoryID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string NID { get; set; }
        public string FatherName { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Qualification { get; set; }
        public string PermanentAddres { get; set; }
        public string JobReferences { get; set; }
        public string Description { get; set; }
        public Nullable<int> CurrentJobStatusID { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual CurrentJobStatu CurrentJobStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }
        public virtual JobCategory JobCategory { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobApply> JobApplies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
