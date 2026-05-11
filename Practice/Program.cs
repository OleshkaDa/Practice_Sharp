using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLPrectice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MysteryCreatures Owlin = new MysteryCreatures("Cовлин", 4, false, "Дальние родственники гигантских сов из Страны фей, совлины бывают различных форм и размеров, от миниатюрных и пушистых до ширококрылых и величественных. Совлины имеют руки и ноги, как и другие гуманоиды, а также крылья, которые растут из спины и плеч.\r\n\r\nКак и обычные совы, совлины обладают не издающими звука перьями, когда они двигаются или летают, что позволяет им легко подкрасться к вам в библиотеке.\r\n\r\nВаш персонаж совлин может вести ночной образ жизни. Или, возможно, ваш персонаж просто склонен пробуждаться гораздо позже, воплощая в себе распространённое прозвище «полуночник».");
            MysteryCreaturesDTO owlinDTOVAR1 = new MysteryCreaturesDTO(Owlin.Name, Owlin.Age, Owlin.IsDangerous, Owlin.Description);
            MysteryCreaturesDTO owllinDTO2VAR = new MysteryCreaturesDTO(Owlin);

            //Создаем путь для штучки
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "Owlin.xml");

            //создаем сериализатор
            //Rласс должен:
            //иметь констурктор без параметров
            //буть публичным
            //все свойства должны быть с публичными get set

            //Как работает
            //ориг объект делаем в дто обхект и отдаем на растерзание сериализации
            //десериализация из файлика получает дто объектт и оттуда тыкаем ориг
            var serializer = new XmlSerializer(typeof(MysteryCreaturesDTO));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, owlinDTOVAR1);
            }


            //десериализуем прикольчик
            MysteryCreaturesDTO LovimSPotoka;
            using (var reader = new StreamReader(filePath))
            {
                LovimSPotoka = (MysteryCreaturesDTO)serializer.Deserialize(reader);
            }

            MysteryCreatures SowlinPoimaliSPotoka = new MysteryCreatures(LovimSPotoka.Name, LovimSPotoka.Age, LovimSPotoka.IsDangerous, LovimSPotoka.Description);
        }

    }
    //вот эта штука это гомункул от основного класса чтоб прога не ругалась
    public class MysteryCreaturesDTO
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsDangerous { get; set; }
        public string Description { get; set; }

        public MysteryCreaturesDTO()
        {

        }
        public MysteryCreaturesDTO(string name, int age, bool dang = false, string deskr = "")
        {
            Name = name;
            Age = age;
            IsDangerous = dang;
            Description = deskr;
        }

        //или коснтуруктор

        public MysteryCreaturesDTO(MysteryCreatures creat)
        {
            Name = creat.Name;
            Age = creat.Age;
            IsDangerous = creat.IsDangerous;
            Description = creat.Description;
        }

    }

    public class MysteryCreatures
    {
        private string _name;
        private int _ageHowLongLives;
        private bool _isDangerous;
        private string _description;
        public string Name => _name;
        public int Age => _ageHowLongLives;
        public bool IsDangerous => _isDangerous;
        public string Description => _description;


        public MysteryCreatures(string name, int age, bool dang=false, string deskr="")
        {
            _name = name;
            _ageHowLongLives = age;
            _isDangerous = dang;
            _description = deskr;
        }
        public MysteryCreatures()
        {

        }
    }
}
