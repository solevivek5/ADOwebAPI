using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class ErrorLog
    {
        /// <summary>
        /// This is the primary key of this table.
        /// </summary>
        public int ErrorKid { get; set; }
        /// <summary>
        /// This is for procedure name.
        /// </summary>
        public string? ProcedureName { get; set; }
        /// <summary>
        /// This column is for error message.
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// This column is for error number.
        /// </summary>
        public int? ErrorNumber { get; set; }
        /// <summary>
        /// This column tells that at which line the error is comming from.
        /// </summary>
        public int? ErrorLine { get; set; }
        /// <summary>
        /// It shows the severity of the error which occured.
        /// </summary>
        public int? ErrorSeverity { get; set; }
        /// <summary>
        /// &apos;A&apos; = active, &apos;D&apos; = deactive
        /// </summary>
        public int? ErrorState { get; set; }
        /// <summary>
        /// This column is for
        /// </summary>
        public string? ErrorManualdesc { get; set; }
        /// <summary>
        /// This is for the insertion date of the error.
        /// </summary>
        public DateTime? ErrorIdate { get; set; }
        /// <summary>
        /// This is for IUsrId.
        /// </summary>
        public int? ErrorIusrId { get; set; }
    }
}
