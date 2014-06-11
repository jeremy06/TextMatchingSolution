using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public static class MessageResponse
    {

        public static string GetMessageResponse(Enum.MessageResponseType responseType)
        {
            var strMessage = string.Empty;
            switch (responseType)
            {
                case Enum.MessageResponseType.ExceptionError:
                    strMessage = "Exception error encountered.";
                    break;

                case Enum.MessageResponseType.ExceptionNoMatches:
                    strMessage = "No matches found.";
                    break;
                    
                case Enum.MessageResponseType.ExceptionNoDataInputFound:
                    strMessage = "No input found.";
                    break;
            }

            return strMessage;

        }

    }
}
