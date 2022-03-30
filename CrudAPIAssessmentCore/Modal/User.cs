using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrudAPIAssessmentCore.Modal
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MidleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string LocationOfElection { get; set; }
        public string Country { get; set; }
        public string CountryIso { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool OtherNationality { get; set; }
        public string PassportPath { get; set; }
        public string ProfilePath { get; set; }
        public string SelfiePath { get; set; }
        public string UtilityBillPath { get; set; }
        public string FacebookSocialLink { get; set; }
        public string LinkedInSocialLink { get; set; }
        public string TweeterSocialLink { get; set; }
        public string InstaSocialLink { get; set; }
        public string YoutubeSocialLink { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
