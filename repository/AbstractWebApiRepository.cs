using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfApp.repository
{
    public abstract class AbstractWebApiRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient client;

        protected AbstractWebApiRepository(HttpClient client)
        {
            this.client = client;
        }

        public Task<IEnumerable<T>> All()
        {
            return GetCollectionAsync(client.BaseAddress + GetCollectionUrlString());            
        }

        internal abstract string GetCollectionUrlString();

        public void Clear()
        {
            // Do nothing;
        }
        public void Delete(T value)
        {
        }
        public T Insert(T value)
        {
            // Do nothing;
            return value;
        }
        public T Update(T value)
        {
            // Do nothing;
            return value;
        }

        private async Task<IEnumerable<T>> GetCollectionAsync(string path)
        {
            IEnumerable<T> collection = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    collection = await response.Content.ReadAsAsync<IEnumerable<T>>();
                }
            }
            catch (Exception)
            {
            }
            return collection;
        }

    }
}
