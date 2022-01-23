//string file = @"d:\1.txt";
//File.Delete(file);
//await File.WriteAllTextAsync(file, "zxc");
//string s = await File.ReadAllTextAsync(file);
//Console.WriteLine(s);
//Console.ReadKey();
// string file = @"d:\1.txt";
//
// var count = await DownLoadHtmlAsync("https://www.baidu.com", file);
//
// Console.WriteLine(count);
//
// Console.ReadKey();


#region 验证 await 线程不一致

// StringBuilder sb = new StringBuilder();
// for (int i = 0; i < 10000000; i++)
// {
//     sb.Append("zxc");
// }

// await File.WriteAllTextAsync(@"d:\1.txt", sb.ToString());
// Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
// string str = await File.ReadAllTextAsync(@"d:\1.txt");
// Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

#endregion

#region 验证异步方法中的代码不会自动开启线程执行

// Console.WriteLine($"Main :{Thread.CurrentThread.ManagedThreadId}");
// await CalcAsync(50000);
//
// static async Task<long> CalcAsync(int n)
// {
//     // Console.WriteLine($"CalcAsync :{Thread.CurrentThread.ManagedThreadId}");
//     // long b = 0;
//     // Random r = new Random();
//     // for (int i = 0; i < n * n; i++)
//     // {
//     //     b += r.NextInt64();
//     // }
//     // return b;
//
//     return await Task.Run(() =>
//     {
//         Console.WriteLine($"CalcAsync :{Thread.CurrentThread.ManagedThreadId}");
//         long b = 0;
//         Random r = new Random();
//         for (int i = 0; i < n * n; i++)
//         {
//             b += r.NextInt64();
//         }
//
//         return b;
//     });
// }

#endregion


// List<Task> list = new List<Task>();
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// Task.WaitAll(list.ToArray());

#region 委托中使用异步

// ThreadPool.QueueUserWorkItem(async (obj) =>
// {
//     while (true)
//     {
//         await File.WriteAllTextAsync("zzz", "zxc");
//     }
// });

#endregion


#region 封装一个异步方法

static async Task<int> DownLoadHtmlAsync(string url, string path)
{
    using (HttpClient httpClient = new HttpClient())
    {
        string html = await httpClient.GetStringAsync(url);
        await File.WriteAllTextAsync(path, html);
        return html.Length;
    }
}

#endregion

#region Task.Result 、 Task.Wait

static string ReadAllText(string path)
{
    string s = File.ReadAllTextAsync(path).Result;
    return s;
}

static void WriteAllText(string path, string contents)
{
    File.WriteAllTextAsync(path, contents).Wait();
}

#endregion

#region 没有Async 的异步方法

// var result = await TestAsync(500);
// Console.WriteLine(result);
//
// static Task<long> TestAsync(int n)
// {
//     return Task.Run(() =>
//     {
//         Console.WriteLine($"CalcAsync :{Thread.CurrentThread.ManagedThreadId}");
//         long b = 0;
//         Random r = new Random();
//         for (int i = 0; i < n * n; i++)
//         {
//             b += r.NextInt64();
//         }
//
//         //return Task.FromResult(b);
//         return b;
//     });
//}

#endregion

#region 高效的等待任务

// List<Task> list = new List<Task>();
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// list.Add(Task.Run(() => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); }));
// //Task.WaitAll(list.ToArray());
// // await Task.WhenAll(list.ToArray());
// while (list.Any())
// {
//    var result = await Task.WhenAny(list.ToArray());
//    list.Remove(result);
// }
//
// Console.WriteLine("zxc");

#endregion


#region 测试高效的等待任务和多线程 那个快

//Stopwatch sw = new Stopwatch();
//sw.Start();
//for (int i = 0; i < 10; i++)
//{
//    await TestWhenAllAndTaskRun();
//}

//sw.Stop();
//Console.WriteLine($"async {sw.ElapsedMilliseconds}");

//Stopwatch sw1 = new Stopwatch();

//List<Task> list1 = new List<Task>();
//sw1.Start();
//for (int i = 0; i < 10; i++)
//{
//    list1.Add(TestWhenAllAndTaskRun());
//}

//Task.WaitAll(list1.ToArray());
//sw1.Stop();
//Console.WriteLine($"noasync {sw1.ElapsedMilliseconds}");

//Stopwatch sw2 = new Stopwatch();

//List<Task> list2 = new List<Task>();

//sw2.Start();
//for (int i = 0; i < 10; i++)
//{
//    list2.Add(Task.Run(async () => { await TestWhenAllAndTaskRun(); }));
//}

//Task.WaitAll(list2.ToArray());
//sw2.Stop();
//Console.WriteLine($"Thread {sw2.ElapsedMilliseconds}");


//static async Task TestWhenAllAndTaskRun()
//{
//    //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    StringBuilder result = new StringBuilder();
//    for (int i = 0; i < 1000000; i++)
//    {
//        result.Append(i.ToString());
//    }

//    for (int i = 0; i < 1000000; i++)
//    {
//        result.Append(i.ToString());
//    }

//    for (int i = 0; i < 1000000; i++)
//    {
//        result.Append(i.ToString());
//    }

//    for (int i = 0; i < 1000000; i++)
//    {
//        result.Append(i.ToString());
//    }
//}

#endregion


#region 取消任务

//CancellationTokenSource cts = new CancellationTokenSource();
//cts.CancelAfter(10000);//指定时间
////cts.Cancel();//直接终止
//CancellationToken cancellationToken = cts.Token;
//await DownloadlAsync("https://www.baidu.com", 100, cancellationToken);
//static async Task DownloadlAsync(string url, int n, CancellationToken cancellationToken = default)
//{
//    using (HttpClient httpClient = new HttpClient())
//    {
//        for (int i = 0; i < n; i++)
//        {
//            string html = await httpClient.GetStringAsync(url);
//            Console.WriteLine(html);
//            #region 判断是否取消
//            if (cancellationToken.IsCancellationRequested)
//            {
//                Console.WriteLine("取消");
//                return;
//            }
//            #endregion

//            #region 直接异常
//            cancellationToken.ThrowIfCancellationRequested();
//            #endregion

//            #region 将参数传递给有 CancellationToken
//            await httpClient.GetAsync(url, cancellationToken);
//            #endregion
//        }
//    }
//}


#endregion



#region 

//List<Task<int>> list = new List<Task<int>>();
//list.Add(Task.Run(() => { return Thread.CurrentThread.ManagedThreadId; }));
//list.Add(Task.Run(() => { return Thread.CurrentThread.ManagedThreadId; }));
//list.Add(Task.Run(() => { return Thread.CurrentThread.ManagedThreadId; }));

//var array = await Task.WhenAll(list.ToArray());

//foreach (var item in array)
//{
//    Console.WriteLine(item);
//}
#endregion


#region  yield

static IEnumerable<string> Test()
{
    for (int i = 0; i < 10; i++)
    {
        yield return i.ToString();

    }
}

static async IAsyncEnumerable<string> Test2()
{
    for (int i = 0; i < 10; i++)
    {
        yield return i.ToString();

    }
}

#endregion