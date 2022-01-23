namespace BuilderPattern
{
    public class Call
    {
        public static void Show()
        {

            IHomeBuilder builder = new Home1("田园风");
            HomeDirector director = new HomeDirector();
            director.CreateCar(builder);
            Home home = builder.Builder();
            home.Play();

            IHomeBuilder builder2 = new Home2("别墅风");
            HomeDirector director2 = new HomeDirector();
            director2.CreateCar(builder2);
            builder2.BuildSwimming();
            builder2.BuildGargen();
            Home home2 = builder2.Builder();
            home2.Play();


            IHomeBuilder builder3 = new Home2("别墅风 链式语法");
            HomeDirector director3 = new HomeDirector();
            director3.CreateCar(builder3);
            builder3.BuildSwimming().BuildGargen();
            //builder3.BuildGargen();
            Home home3 = builder2.Builder();
            home2.Play();
        }
    }
}