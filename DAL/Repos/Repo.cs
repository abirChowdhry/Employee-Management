namespace DAL.Repos
{
    internal class Repo
    {
        protected EMPContext db;
        internal Repo()
        {
            db = new EMPContext();
        }
    }
}
