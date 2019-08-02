using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOWorld.Common
{
    public class CommonHelper
    {
        #region Contants
        public const string RegexEmail = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}";

        public const string DateFormate = "dd/MM/yyyy";

        public const string DateTimeFormate = "dd/MM/yyyy HH:mm";

        public const string TimeFormate = "HH:mm";

        public const string CommonErrorMsg = "Something Went Wrong. Please Try Again Later.";
        #endregion

        #region Methods
        public static string GetErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                var errorMessage = String.Empty;
                if (ex == null) return errorMessage;
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += Environment.NewLine + GetErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    errorMessage += Environment.NewLine + ex.StackTrace;

                errorMessage = errorMessage.Replace("An error occurred while updating the entries. See the inner exception for details.", "");
                return errorMessage;
            }
            catch
            {
                return ex != null ? ex.Message : string.Empty;
            }
        }

        public static string GetDeleteErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                var errorMessage = String.Empty;
                if (ex == null) return errorMessage;
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += Environment.NewLine + GetDeleteErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    errorMessage += Environment.NewLine + ex.StackTrace;

                errorMessage = errorMessage.Replace("\"", " ");
                errorMessage = errorMessage.Replace("'", " ");
                return errorMessage;
            }
            catch
            {
                return ex != null ? ex.Message : string.Empty;
            }
        }

        public static string GetDeleteException(Exception exception)
        {
            string errorMessage = GetDeleteErrorMessage(exception, false);
            return errorMessage.Contains("The DELETE statement conflicted with the REFERENCE constraint") ? ParseDeleteMessage(errorMessage) : errorMessage;
        }

        private static string ParseDeleteMessage(string message)
        {
            try
            {
                const string str = "This record link to another record(s), you can not delete this record";
                return str;
            }
            catch
            {
                return message;
            }
        }

        public static string ShowAlertMessage(string message)
        {
            message = message.Replace("'", " ");
            var strString = @"<script type='text/javascript' language='javascript'>$(function() { showMessageOnly(' " + message + "' , 'popup-error'); })</script>";
            return strString;
        }

        public static string ShowAlertMessage(Exception exception)
        {
            string message = GetErrorMessage(exception);
            message = message.Replace("'", " ");
            var strString = @"<script type='text/javascript' language='javascript'>$(function() { showMessageOnly(' " + message + "') , 'popup-error'; })</script>";
            return strString;
        }

        public static List<int> ConvertStringToIntList(string jointid)
        {

            if (string.IsNullOrEmpty(jointid))
            {
                return null;
            }

            return jointid.Split(',').Select(int.Parse).ToList();
        }
        
        #endregion
    }
}
