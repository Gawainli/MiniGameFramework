/// <summary>
/// 全局单例对象（非线程安全）
/// </summary>
/// <typeparam name="T"></typeparam>

namespace UnityGameFramework.Runtime
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static T s_Instance = default(T);

        public static T Instance
        {
            get
            {
                if (null == s_Instance)
                {
                    s_Instance = new T();
                    s_Instance.Init();
                }

                return s_Instance;
            }
        }

        public static bool IsValid
        {
            get { return s_Instance != null; }
        }

        protected Singleton()
        {

        }

        protected virtual void Init()
        {

        }

        public virtual void Active()
        {

        }

        public virtual void Release()
        {
            if (s_Instance != null)
            {
                s_Instance = null;
            }
        }
    }
}