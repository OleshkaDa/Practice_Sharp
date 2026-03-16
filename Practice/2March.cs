using System.Security.Cryptography.X509Certificates;

namespace Aluminewaya_Chashka
{
    public class Task1
    {
        public static void Main()
        {
            Pribori Kolpachok = new Pribori(false, "Gromko postukivaniem", "Fosfor");
            Vilka Bilibaka = new Vilka(4, 6, true, "Molcha", "Uran");
            Bilibaka.Print();
            Kolpachok.Print();
            Console.WriteLine(Bilibaka.Kakestttt);
            //Console.WriteLine(Bilibaka.ToString());
        }
    }

    public class Pribori
    {
        private bool IsExist;
        private string KakEst;
        private string Material;

        public bool StudentkaMolodenkaya => IsExist;
        public string Kakestttt => KakEst;
        public string Mamamama => Material;

        public Pribori(bool existing, string kakest, string material)
        {
            IsExist = existing;
            KakEst = kakest;
            Material = material;

        }

        public virtual void Print()
        {
            Console.WriteLine($"Студентка?Молоденькая? {StudentkaMolodenkaya}. Че как двигаешься по жизни {Kakestttt}. Твои родители случайно не {Mamamama}? Тогда почему ты такая яркая?");
        }


    }

    public class Vilka : Pribori 
    {
        private int KolichestvoZupchikov;
        private int KolichestvoNamotannihMakaron;
        public int kokoko => KolichestvoZupchikov;
        public int Kolmamama => KolichestvoNamotannihMakaron;


        public Vilka(int kolzub, int kolmak, bool existing, string kakestbebebe, string material) : base(existing, kakestbebebe, material)
        {
            KolichestvoZupchikov = kolzub;
            KolichestvoNamotannihMakaron = kolmak;
        }

        public override void Print()
        {
            Console.WriteLine("Вы позвонили по телефону доверия. ♫♮♫b#♫ b♫‾b♫");
            Console.WriteLine($"Сколько можно ударить в глаз? {kokoko}. А если подумать? {Kolmamama}. Чё как кушается? {Kakestttt}. Твои родители случайно не {Mamamama}? Тогда почему ты такая взрывная?");
        }

    }
}
