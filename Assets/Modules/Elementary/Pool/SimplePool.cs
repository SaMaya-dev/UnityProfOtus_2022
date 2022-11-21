using System;
using System.Collections.Generic;

public class SimplePool
{
    private Stack<object> stack;
    private Func<object> factoryMethod;

    public SimplePool(Func<object> factoryMethod)
    {
        stack = new Stack<object>();
        this.factoryMethod = factoryMethod;
    }

    public object GetObject()
    {
        lock (stack)
        {
            if (stack.Count > 0)
                return stack.Pop();
        }

        if (factoryMethod != null)
            return factoryMethod();

        return null;
    }

    public void ReleaseObject(object o)
    {
        lock (stack)
        {
            stack.Push(o);
        }
    }
}