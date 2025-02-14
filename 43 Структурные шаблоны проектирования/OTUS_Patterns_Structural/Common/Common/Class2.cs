namespace Common
{
    public interface IA
    {
        public int Prepare(int x);
    }
    
    public class A : IA
    {
        public int Prepare(int x)
        {
            return x + 1;
        }
    }
    
    public class B : A
    {
        public int Do(int x)
        {
            return Prepare(x)^2;
        }
    }
    
    public class C
    {
        private A _a;
        
        public C(A a)
        {
            _a = a;
        }
        
        public int Do(int x)
        {
            return _a.Prepare(x)^2;
        }
    }
    
    public class D
    {
        private IA _a;
        
        public D(IA a)
        {
            _a = a;
        }
        
        public int Do(int x)
        {
            return _a.Prepare(x)^2;
        }
    }
    
    public class AA : IA
    {
        private IA _a;
        
        public AA(IA a)
        {
            _a = a;
        }

        public int Prepare(int x)
        {
            return _a.Prepare(x) + 1;
        }
    }
}