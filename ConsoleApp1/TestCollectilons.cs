using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestCollectilons
    {
        List<Team> teams;
        List<string> strings;
        Dictionary<Team, ResearchTeam> TeamsAndResearchesDict;
        Dictionary<string, ResearchTeam> StringsAndResearchDict;

        public static ResearchTeam GenerateReserchTeamObject(int index)
        {
            return new ResearchTeam("Research" + index, "Oranization" + index, 1 + index, TimeFrame.Year);
        }

        public TestCollectilons(int count)
        {
            teams = new List<Team>();
            strings = new List<string>();
            TeamsAndResearchesDict = new Dictionary<Team, ResearchTeam>();
            StringsAndResearchDict = new Dictionary<string, ResearchTeam>();

            for(int i = 0; i < count; i++)
            {
                ResearchTeam research1 = GenerateReserchTeamObject(i);
                Team team1 = new Team("OrgName"+i,1+i);
                string str = "String " + i;
                teams.Add(team1);
                strings.Add(str);
                TeamsAndResearchesDict.Add(team1, research1);
                StringsAndResearchDict.Add(str, research1);
            }
        }
        public string Time(int n)
         {
             ResearchTeam rt = new ResearchTeam() { RegistrationGetSet = n };
             string info = "";
             bool temp;
             System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
             time.Start();
             Team temp1 = rt as Team;
             temp = TestTeamList.Contains(temp1);
             time.Stop();
             info += String.Format("Время поиска элемента в List<Team> - {0}\n", time.Elapsed);
 
             time.Reset();
             time.Start();
             string temp2 = rt.ToString();
             temp = TestStringList.Contains(temp2);
             time.Stop();
             info += String.Format("Время поиска элемента в List<string> - {0}\n", time.Elapsed);
 
             time.Reset();
             time.Start();
             temp = TestTeamDictionary.ContainsKey(temp1);
             time.Stop();
             info += String.Format("Время поиска по ключу в Dictionary<Team,ResearchTeam> - {0}\n", time.Elapsed);
 
             time.Reset();
             time.Start();
             temp = TestTeamDictionary.ContainsValue(rt);
             time.Stop();
             info += String.Format("Время поиска по значению в Dictionary<Team,ResearchTeam> - {0}\n", time.Elapsed);
 
             time.Reset();
             time.Start();
             temp = TestStringDictionary.ContainsKey(temp2);
             time.Stop();
             info += String.Format("Время поиска по ключу в Dictionary<string,ResearchTeam> - {0}\n", time.Elapsed);
 
             time.Reset();
             time.Start();
             temp = TestStringDictionary.ContainsValue(rt);
             time.Stop();
             info += String.Format("Время поиска по значению в Dictionary<string,ResearchTeam> - {0}\n", time.Elapsed);
 
             return info;
        }
}
}
