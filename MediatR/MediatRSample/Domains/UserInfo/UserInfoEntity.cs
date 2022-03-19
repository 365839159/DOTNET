namespace MediatRSample.Domains
{
    public class UserInfoEntity : BaseEntity
    {
        public int Id { get; init; }//1 属性是只读或者只能被类的内部修改（set 定义为 private 或者 init）
        public string? UserName { get; private set; }//
        private string? passwordHash;//3不属于属性的字段映射为数据列（builder.Property("成员变量名")）
        public DateTime CreateTime { get; init; }
        private string? remark;
        public string? Remark { get { return remark; } }//4只读属性（HasField（"成员变量名"））
        public string? Tag { get; set; }//5 不需要映射到数据库（Ignore）
        private UserInfoEntity() { }
        //2 定义有参数的构造函数
        public UserInfoEntity(string? userName)
        {
            UserName = userName;
            CreateTime = DateTime.Now;
        }
        public void ChangeUserName(string newUserName)
        {
            this.UserName = newUserName;
            this.AddDomainEvent(new UserInfoNotification(this.UserName));
        }
        public void ChangePassword(string newPassWord)
        {
            if (newPassWord.Count() < 6)
            {
                throw new ArgumentException("密码太短");
            }
            this.passwordHash = newPassWord;
        }
    }
}
