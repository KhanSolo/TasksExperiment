using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
//[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
//[module: RefSafetyRules(11)]

namespace AsyncDesugaring;
public sealed class Klass
{
    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct MainStateMachine : IAsyncStateMachine
    {
        public int _state;

        public AsyncTaskMethodBuilder _asyncTaskMethodBuilder;

        private TaskAwaiter _taskAwaiter;

        private void MoveNext()
        {
            int num = _state;
            try
            {
                TaskAwaiter awaiter;
                if (num != 0)
                {
                    Console.WriteLine("before");
                    awaiter = Task.Delay(1000).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_state = 0);
                        _taskAwaiter = awaiter;
                        _asyncTaskMethodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                }
                else
                {
                    awaiter = _taskAwaiter;
                    _taskAwaiter = default(TaskAwaiter);
                    num = (_state = -1);
                }
                awaiter.GetResult();
                Console.WriteLine("after");
            }
            catch (Exception exception)
            {
                _state = -2;
                _asyncTaskMethodBuilder.SetException(exception);
                return;
            }
            _state = -2;
            _asyncTaskMethodBuilder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(
            //[Nullable(1)]
        IAsyncStateMachine stateMachine)
        {
            _asyncTaskMethodBuilder.SetStateMachine(stateMachine);
        }

        void IAsyncStateMachine.SetStateMachine(
            //[Nullable(1)] 
        IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            SetStateMachine(stateMachine);
        }
    }

    //[NullableContext(1)]
    [AsyncStateMachine(typeof(MainStateMachine))]
    public Task Main()
    {
        MainStateMachine stateMachine = default(MainStateMachine);
        stateMachine._asyncTaskMethodBuilder = AsyncTaskMethodBuilder.Create();
        stateMachine._state = -1;
        stateMachine._asyncTaskMethodBuilder.Start(ref stateMachine);
        return stateMachine._asyncTaskMethodBuilder.Task;
    }
}
