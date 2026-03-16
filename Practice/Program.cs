
namespace ConsolkaBilibaka
{
    public class Program
    {
        public static void Main()
        {
            JapanPunishment_Harakiri nakasanie = new JapanPunishment_Harakiri(7);
            nakasanie.Method1();
            nakasanie.Method2();
            nakasanie.Method3();

            Punishment nakazanie = new JapanPunishment_Harakiri(16);
            nakazanie.Method1();
            nakazanie.Method2();
            nakazanie.Method3();

        }
    }




    public abstract class Punishment
    {
        protected int _number; // количество ошибок

        public virtual string _lastWords => "Адьёс амигос";
        public abstract string LastWords { get; }

        public Punishment(int number)
        {
            _number = number;
        }

        public void Method1()
        {
            Console.WriteLine("Наказан!");
        }

        public virtual void Method2()
        {
            Console.WriteLine("Punished!");
        }

        public abstract void Method3();
    }






    public class JapanPunishment_Harakiri : Punishment //харакари
    {
        public JapanPunishment_Harakiri(int number) : base(number)
        {

        }

        public override string LastWords => "私の罪をお許しください";

        public new void Method1()
        {
            Console.WriteLine("罰せられた");
        }

        public override void Method2()
        {
            Console.WriteLine("切腹という形での刑罰が続く");
        }

        public override void Method3()
        {
            Console.WriteLine($"{_number}の罪の代償を払え");
        }
    }








    public class SchoolPunishment_Dvoika : Punishment //двойка
    {
        public SchoolPunishment_Dvoika(int number) : base(number)
        {

        }

        public override string LastWords => "Больно надо мне учится!";

        public new void Method1()
        {
            base.Method1();
        }

        public override void Method2()
        {
            Console.WriteLine("В разработке, подойдите позже!");
        }

        public override void Method3()
        {
            Console.WriteLine("В разработке, подойдите позже!");
        }
    }






    public class AdultPunishment_Uvolnenie : Punishment //увольнение
    {
        public AdultPunishment_Uvolnenie(int number) : base(number)
        {

        }

        public override string LastWords => "Ну ладно пойду в пятерочке работать";
        public override void Method3()
        {
            throw new NotImplementedException();
        }
    }
}
