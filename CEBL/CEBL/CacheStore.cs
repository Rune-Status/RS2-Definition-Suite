namespace CEBL
{
    using System;
    using System.IO;

    public class CacheStore
    {
        public FileStream cache_dat;
        public FileStream[] cache_idx = new FileStream[5];

        public CacheStore(string s)
        {
            if (!File.Exists(s + @"\main_file_cache.dat"))
            {
                throw new FileNotFoundException("Missing cache files.");
            }
            try
            {
                this.cache_dat = File.Open(s + @"\main_file_cache.dat", FileMode.Open);
                for (int i = 0; i < 5; i++)
                {
                    if (!File.Exists(s + @"\main_file_cache.idx" + i))
                    {
                        throw new FileNotFoundException("Missing cache files.");
                    }
                    this.cache_idx[i] = File.Open(s + @"\main_file_cache.idx" + i, FileMode.Open);
                }
            }
            catch (Exception)
            {
                throw new IOException("Cache in use elsewhere.");
            }
        }

        public void Close()
        {
            if (this.cache_dat != null)
            {
                this.cache_dat.Close();
            }
            for (int i = 0; i < 5; i++)
            {
                if (this.cache_idx[i] != null)
                {
                    this.cache_idx[i].Close();
                }
            }
        }
    }
}

