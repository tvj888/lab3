using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    public class ResearchTeamCollection<TKey>
    {
        //закрытое поле типа System.Collections.Generic.Dictionary<TKey, ResearchTeam>;

        private Dictionary<TKey, ResearchTeam> researchteamDictionary;

        //закрытое поле типа KeySelector<TKey> для хранения экземпляра делегата сметодом, вычисляющим ключ для объекта ResearchTeam;

        private KeySelector<TKey> researchteamKey;

        // конструктор c одним параметром типа KeySelector<TKey> ;

        public ResearchTeamCollection(KeySelector<TKey> tKey)
        {
            this.myKeySelector = tKey;
            researchteamDictionary = new Dictionary<TKey, ResearchTeam>();

        }

        //метод void AddDefaults (), c помощью которого можно добавить некоторое число элементов ResearchTeam для инициализации коллекции по умолчанию;

        public void AddDefaults()
        {
            ResearchTeam tempRT = new ResearchTeam();
            // вызываю епаный метод для высчитывания ключа, на который указывает ДЕГЕНЕРАТ
            TKey key = myKeySelector(tempRT);
            researchteamDictionary.Add(key, tempRT);

        }

        // метод void AddResearchTeams(params ResearchTeam[] ) для добавления элементов в коллекцию Dictionary<TKey, ResearchTeam>;
        //ВОТ ТУТ ПОШЛО ЕБАЛОВО


        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            ResearchTeam tempRT = new ResearchTeam();
            TKey key = myKeySelector(tempRT);
            researchteamDictionary.Add(TKey, researchTeams);
        }

        //НА САМОМ ДЕЛЕ ВОТ ТУТ
        // перегруженную версию виртуального метода string ToString() для
        // формирования строки, содержащей информацию обо всех элементах
        // коллекции Dictionary<TKey, ResearchTeam>, в том числе значения всех полей,
        // включая список участников проекта и список публикаций для каждого
        // элемента ResearchTeam;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var team in researchteamDictionary)
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

        // метод string ToShortString(), который формирует строку с информацией обо всех элементах коллекции Dictionary<TKey, ResearchTeam>, содержащую
        // значения всех полей, число участников проекта и число публикаций для каждого элемента ResearchTeam, но без списков участников и публикаций.

        public string ToShortString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var team in researchteamDictionary)
            {
                sb.AppendFormat($"Название иследования: { team.ReasearchName } \n Организация: { team.Name } \n Регистрационный номер: { team.RegNomber }  \n Длительность исследования: { team.ResearchTime } \n Количество статей: \n { team.Papers.Count } \n Количество участников: \n { team.Persons.Count } \n");
            }
            return sb.ToString();

        }

        //posledniyy klassi просто у влада спиздил, не ебу как сделать
        //не нашел норм инфы по ебаному диктионари
        //я не шарю
        //jizn' tlen
        //!!!!1

        public void SortByRegNomber()
        {
            researchteamDictionary.Sort((s1, s2) => s1.CompareTo(s2));
        }

        public void SortByResearchName()
        {
            researchteamDictionary.Sort((s1, s2) => s1.Compare(s1, s2));
        }

        public void SortByPapersCount()
        {
            researchteamDictionary.Sort(new ResearchTeamComparer());
        }
    }
}



