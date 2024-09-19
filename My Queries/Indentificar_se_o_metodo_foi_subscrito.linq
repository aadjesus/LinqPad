<Query Kind="Program">
  <Reference>C:\BgmRodotec\Projeto Trend\BgmRodotec.Compras\packages\Common.Logging.Core.3.3.1\lib\net40\Common.Logging.Core.dll</Reference>
  <Reference>C:\BgmRodotec\Projeto Trend\BgmRodotec.Compras\packages\Common.Logging.3.3.1\lib\net40\Common.Logging.dll</Reference>
  <Reference>C:\BgmRodotec\Projeto Trend\BgmRodotec.Compras\packages\Quartz.2.4.1\lib\net40\Quartz.dll</Reference>
  <Reference>C:\BgmRodotec\Projeto Trend\BgmRodotec.Compras\packages\Serilog.2.3.0\lib\net46\Serilog.dll</Reference>
  <Namespace>Quartz</Namespace>
  <Namespace>Quartz.Impl</Namespace>
  <Namespace>Serilog</Namespace>
</Query>

public static void Main()
{
	var x1 = new Executar1();
	x1.Executar();
}

public class Executar1
{
	public void Executar()
	{
		//		var assemblyName = GetType().Assembly.GetReferencedAssemblies()
		//			.FirstOrDefault(w => w.Name == "BgmRodotec.Compras.Api");
		//		var tipos = Assembly.Load(assemblyName).GetTypes();
		
		var tipos = new Type[] { typeof(MyClass3Bo) };
		
        var listaService = tipos
            .Where(w => w.BaseType == typeof(ServiceBo) &&
                            RetornarMetodos(w)
                                .Any());

        foreach (var tipo in listaService)
        	ExecutarMetodos(tipo);	
	}
	
	private void ExecutarMetodos(Type tipo)
	{
//		var schedFact = new StdSchedulerFactory();
//		var sched = schedFact.GetScheduler();
	
//		protected void Schedule<TJob>(string JobId) where TJob: IJob
//      {
//          IJobDetail job = JobBuilder.Create<TJob>()
//                  .WithIdentity(JobId, "ComprasNotificacaoService")
//                  .Build();
//
//          ITrigger trigger = TriggerBuilder.Create()
//              .WithIdentity(JobId, "ComprasNotificacaoService")
//              .StartNow()
//          .WithCronSchedule("0 0/1 * * * ?") //A cada 1 minuto
//              .Build();
//          sched.ScheduleJob(job, trigger);
//      }	
	
	
		var service = Activator.CreateInstance(tipo) as ServiceBo;		
		foreach (var metodo in RetornarMetodos(tipo))
		{
			var parametros = CriarParametros(metodo);
		    try
		    {										
		        metodo.Invoke(service, parametros.ToArray());				
		    }
		    catch (Exception ex)
		    {
				parametros.Add(ex);
		    }
			finally
			{
				Erro(parametros);
			}
		}
	}
	
	private void Erro(List<object> parametros)
	{
		var parametro = parametros
			.FirstOrDefault(f=> f != null);
			
		if (parametro == null)
			return;
	
		var listaException = new List<Exception>();		
		if (parametro is List<Exception>)
			listaException.AddRange(parametro as List<Exception>);
		else
			listaException.Add(parametro as Exception);
		
        foreach (var item in listaException.Where(w=> w != null))
			item.Dump("1");

	}	
	
	private List<object> CriarParametros(MethodInfo metodo)
	{
		var retorno = new List<object>();					
		if (ValidarTipo(metodo, typeof(List<Exception>)))
			retorno.Add(new List<Exception>());
		else if (ValidarTipo(metodo, typeof(Exception)))
			retorno.Add(null);
			
		return retorno;
	}
	
	private bool ValidarTipo(MethodInfo metodo, Type tipo)
	{
		var parametro = metodo.GetParameters().FirstOrDefault();
		
		return parametro != null && parametro
			.ParameterType.GetElementType().GetProperties()
			.Any(a=> a.DeclaringType == tipo);						
	}
	
	private IEnumerable<MethodInfo> RetornarMetodos(Type tipo)
	{
        return tipo.GetMethods()
            .Where(w => w.ReflectedType == w.DeclaringType &&
                        w != w.GetBaseDefinition());
	}
}


#region Advanced
	

	public interface IServiceBo
    {
		void Executar(ref Exception exception);
        void Executar(ref List<Exception> listaException);
    }

    public abstract class ServiceBo : IServiceBo
    {
        public virtual void Executar(ref List<Exception> listaException){}
		
		public virtual void Executar(ref Exception exception){}		
    }

    public class MyClass3Bo : ServiceBo
    {
		public override void Executar(ref Exception exception)
        {         
			DateTime.Now.Dump();
        }
    }

	public class JobBase : IJob
    {
        private string _jobId;
        private Stopwatch _stopwatch;
        private ILogger _log;

        public virtual void Execute(IJobExecutionContext context)
        {
            _log = context.Scheduler.Context["ILogger"] as ILogger;
        }

        public JobBase()
        {
            _jobId = GetType().Name;
            _stopwatch = new Stopwatch();
        }

        protected void LogStart()
        {
            Log(string.Format("[INICIO] '{0}'", _jobId));
            _stopwatch.Start();
        }

        protected void LogEnd()
        {
            _stopwatch.Stop();
            Log(string.Format("[FIM] '{0}' {1} ms de execução", _jobId, _stopwatch.ElapsedMilliseconds));
        }

        protected void Log(string message)
        {
            if (_log != null)
                _log.Information(message);
        }

        protected void LogError(Exception exp)
        {
            if (exp != null && _log != null)
                _log.Error(exp, string.Format("Erro na tarefa '{0}' ", _jobId));
        }
    }
	
	public class Teste : IServiceBo ,IJob
	{
        public virtual void Executar(ref List<Exception> listaException){}
		
		public virtual void Executar(ref Exception exception){}		
	
		public virtual void Execute(IJobExecutionContext context)
        {        
		
        }
	}
	
#endregion