namespace CoffeMaker
{
    public class DB
    {
        public int CF_ID { set; get; }
        public double Water_Qu { set; get; }
        public double Sugar_Qu { set; get; }
        public double Coffe_Qu { set; get; }
        public int Price { set; get; }

        public DB(int CF_ID,double Water_Qu, double Sugar_Qu,double Coffe_Qu,int Price)
        {
            this.CF_ID = CF_ID;
            this.Water_Qu = Water_Qu;
            this.Sugar_Qu = Sugar_Qu;
            this.Coffe_Qu = Coffe_Qu;
            this.Price = Price;
        }
    }
}