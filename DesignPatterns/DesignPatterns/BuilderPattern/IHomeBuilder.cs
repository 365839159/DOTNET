namespace BuilderPattern
{
    public interface IHomeBuilder
    {
        /// <summary>
        /// 墙壁
        /// </summary>
        IHomeBuilder BuildWalls();
        /// <summary>
        /// 门
        /// </summary>
        IHomeBuilder BuildDoors();
        /// <summary>
        /// 窗
        /// </summary>
        IHomeBuilder BuildWindows();
        /// <summary>
        /// 屋顶
        /// </summary>
        IHomeBuilder BuildRoof();
        /// <summary>
        /// 泳池
        /// </summary>
        IHomeBuilder BuildSwimming();
        /// <summary>
        /// 车库
        /// </summary>
        IHomeBuilder BuildGargen();

        Home Builder();
    }
}