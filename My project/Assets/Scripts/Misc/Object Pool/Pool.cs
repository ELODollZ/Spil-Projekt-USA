//af Rasmus

namespace Misc.Pool
{
    public class Pool<t>
    {
        t[] pool;
        int next = 0;

        public Pool(int poolSize)
        {
            pool = new t[poolSize];
        }

        public void SetPool (t[] pool)
        {
            this.pool = pool;
        }

        public t GetNext()
        {
            if (next == pool.Length)
            {
                next = 0;
            }
            return pool[next++];
        }
        
    }
}
