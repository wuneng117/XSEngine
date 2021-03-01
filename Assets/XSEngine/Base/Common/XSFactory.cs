using XSEngine.Core;

namespace XSEngine.Base
{
    public class XSFactory : CoreFactory
    {
        
        /************************* 所有框架内的对象都是由工厂模式创建的 begin ***********************/

        // 触发器触发事件
        public static XSBattleEmitter CreateBattleEmitter() => new XSBattleEmitter();

        /************************* 所有框架内的对象都是由工厂模式创建的  end  ***********************/
    }
}
