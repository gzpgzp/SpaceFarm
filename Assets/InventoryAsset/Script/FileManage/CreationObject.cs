using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Script.FileManage
{
    public class CreationObject<T> where T : new()
    {
        
        public static Func<T> objCreator = null;

        public static T New()
        {
            if (objCreator == null)
            {
                Type objectType = typeof(T);
                
                ConstructorInfo defaultCtor = objectType.GetConstructor(Type.EmptyTypes);
                
                DynamicMethod dynMethod = new DynamicMethod(
                    name: string.Format("_{0:N}", Guid.NewGuid()),
                    returnType: objectType,
                    parameterTypes: null);

                var gen = dynMethod.GetILGenerator();
                gen.Emit(OpCodes.Newobj, defaultCtor);
                gen.Emit(OpCodes.Ret);

                objCreator = dynMethod.CreateDelegate(typeof(Func<T>)) as Func<T>;
            }
            
            return objCreator();   
        }
    }
}