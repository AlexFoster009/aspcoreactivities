using System;

namespace Domain
{
    public class Value
    {
        /*
            with entifty framework this property named Id
            will act as the primary key for its table in teh database.
        */
        public int Id { get; set; }
        public string Name {get; set;}
    }
}
