using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysToDialog
{
    [Serializable]
    public class QuestEntry
    {
        public String QuestType;
        public String ListIndex;

        public QuestEntry(String strType, String strIndex)
        {
            QuestType = strType;
            ListIndex = strIndex;
        }
    }
}
