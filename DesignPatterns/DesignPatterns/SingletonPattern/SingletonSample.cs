namespace SingletonPattern
{
    public class SingletonSample
    {
        /// <summary>
        /// 1、构造函数私有化
        /// </summary>
        private SingletonSample()
        {
            Console.WriteLine($"{this.GetType().Name}被构造一次 {Thread.CurrentThread.ManagedThreadId}");
        }
        /// <summary>
        /// 2、提供全局访问点返回实例
        /// </summary>
        /// <returns></returns>
        public static SingletonSample GetInstance()
        {
            if (_instance is null)
                lock (obj)
                    if (_instance is null)
                        _instance = new SingletonSample();
            return _instance;
        }
        /// <summary>
        /// 保存实例对象
        /// </summary>
        private static SingletonSample? _instance = null;
        private static object obj = new object();

        public void Show()
        {
            Thread.Sleep(100);
            Console.WriteLine($"This is {this.Id}_{this.Name} {this.GetType().Name} {Thread.CurrentThread.ManagedThreadId}");
        }
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}