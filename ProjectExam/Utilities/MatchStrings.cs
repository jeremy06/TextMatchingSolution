using System.Globalization;
using System.Runtime.Remoting.Messaging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Targets.Wrappers;
using Utilities.Helpers;
using Enum = Utilities.Helpers.Enum;

namespace Utilities
{
    public class MatchStrings: ITextMatch
    {
        private static readonly Logger _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
        private const string MainText = @"Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";


        public MatchStrings()
        {
            
        }

        public string ProcessInput(string subText)
        {
            if (string.IsNullOrEmpty(subText))
                return MessageResponse.GetMessageResponse(Enum.MessageResponseType.ExceptionNoDataInputFound);

            var position = "";
            const int diff = 32;

            try
            {
                for (var i = 0; i < MainText.Length; i++)
                {
                    bool find = false;

                    if (subText[0] == MainText[i] || subText[0] + diff == MainText[i] || subText[0] - diff == MainText[i])
                    {
                        find = true;
                        for (var j = 1; j < subText.Length; j++)
                        {
                            if (subText[j] != MainText[i + j] && MainText[i + j] != subText[j] + diff && MainText[i + j] != subText[j] - diff)
                            {
                                find = false;
                                break;
                            }
                        }

                        if (find)
                        {
                            var pos = i + 1;
                            if (position.Length == 0)
                            {
                                position += pos.ToString(CultureInfo.InvariantCulture);
                            }
                            else
                                position += ", " + pos.ToString(CultureInfo.InvariantCulture);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("{0} | {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex));
                return MessageResponse.GetMessageResponse(Enum.MessageResponseType.ExceptionError);
            }
            if (string.IsNullOrEmpty(position)) position = "<no matches>";

            return position;
        }

       
    }
}
