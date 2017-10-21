using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class ResearchTeamCollection
    {
        private List<ResearchTeam> _reseatchTeams;

        public int MinRegNomber
        {
            get
            {
                if (_reseatchTeams.Any())
                {
                    return _reseatchTeams.Min(t => t.RegNomber);
                }
                return 0;
            }
        }

        public IEnumerable<ResearchTeam> TwoYearsLong
        {
            get { return _reseatchTeams.Where(team => team.ResearchTime == TimeFrame.TwoYears); }
        }

        public ResearchTeamCollection()
        {
            _reseatchTeams = new List<ResearchTeam>();
        }

        public List<ResearchTeam> NGrop(int value)
        {
            var group = _reseatchTeams.Where(team => team.Persons.Count == value);
            return group.ToList();
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                _reseatchTeams.Add(new ResearchTeam());
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            _reseatchTeams.AddRange(researchTeams);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var team in _reseatchTeams)
            {
                String papers = "";
                for (int i = 0; i < team.Papers.Count; i++)
                {
                    papers += Convert.ToString(team.Papers[i] + "\n");
                }
                String members = "";
                for (int i = 0; i < team.Persons.Count; i++)
                {
                    members += Convert.ToString(team.Persons[i] + "\n");
                }
                sb.AppendFormat($"Название иследования: { team.ReasearchName } \n Организация: { team.Name } \n Регистрационный номер: { team.RegNomber }  \n Длительность исследования: { team.ResearchTime } \n Статьи: \n { papers } \n Команда: \n { members } \n");
            }
            return sb.ToString();
        }

        public string ToShortString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var team in _reseatchTeams)
            {
                sb.AppendFormat($"Название иследования: { team.ReasearchName } \n Организация: { team.Name } \n Регистрационный номер: { team.RegNomber }  \n Длительность исследования: { team.ResearchTime } \n Количество статей: \n { team.Papers.Count } \n Количество участников: \n { team.Persons.Count } \n");
            }
            return sb.ToString();
        }

        public void SortByRegNomber()
        {
            _reseatchTeams.Sort((s1, s2) => s1.CompareTo(s2));
        }

        public void SortByResearchName()
        {
            _reseatchTeams.Sort((s1, s2) => s1.Compare(s1, s2));
        }

        public void SortByPapersCount()
        {
            _reseatchTeams.Sort(new ResearchTeamComparer());
        }
    }
}
