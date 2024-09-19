<Query Kind="Program" />

internal void Teste()
        {
            using (var sessao = _daoBase.CreateSession())
            {
                //var numRecords = sessao.CreateCriteria<UsuarioFornecedor>()
                //    .SetProjection(Projections.RowCountInt64())
                //    .UniqueResult<long>();

                //.Add(Restrictions.Between(Projections.SqlProjection("rownum", new string[] { "RowNumber" }, new IType[] { NHibernateUtil.Int64 }), rowIndex, rowIndex + pageSize));

                var metadata = sessao.SessionFactory.GetClassMetadata(typeof(UsuarioFornecedor)) as NHibernate.Persister.Entity.SingleTableEntityPersister;

                Console.WriteLine(metadata);
                Expression<Func<UsuarioFornecedor, bool>> condicao =
                    x1 => x1.Id == 500 &&
                          x1.Fornecedor.Ativo &&
                          x1.Usuario.Id == 300 &&
                          x1.Fornecedor.Empresa.Id == 10 &&
                          x1.Fornecedor.EnderecoFatura.Bairro == "xxxxxxxxx";

                var query = sessao
                  .Query<UsuarioFornecedor>()
                  .Where(condicao)
                  .Select(s => s.GetType().GetProperty(metadata.IdentifierPropertyName).Name)
                  ;
                //Console.WriteLine(query.Count());


                //var expression = query.Expression;
                //var provider = query.Provider as INhQueryProvider;
                //MethodInfo prepareQueryMethod = typeof(INhQueryProvider).GetMethod("PrepareQuery", BindingFlags.Instance | BindingFlags.NonPublic);
                //object[] arguments = new object[] { expression, null, null };
                //NhLinqExpression nhLinqExpression1 = prepareQueryMethod.Invoke(provider, arguments) as NhLinqExpression;
                //ExpressionToHqlTranslationResults translationResults = nhLinqExpression1.ExpressionToHqlTranslationResults;
                //HqlQuery hql = translationResults.Statement as HqlQuery;

                //var x34 = System.Linq.Expressions.Expression.Lambda(condicao, condicao.Parameters.FirstOrDefault());
                //if (x34 == null)
                //{
                //}

                var sessionImp = sessao as ISessionImplementor;
                var nhLinqExpression = new NhLinqExpression(query.Expression, sessionImp.Factory);
                var translatorFactory = new ASTQueryTranslatorFactory();
                var translators = translatorFactory.CreateQueryTranslators(nhLinqExpression, null, false, sessionImp.EnabledFilters, sessionImp.Factory).FirstOrDefault();

                var sqlDelete = string.Format(
                    "Delete {0} where {1} IN ({2})",
                    metadata.TableName,
                    metadata.IdentifierPropertyName,
                    translators.SQLString);

                Func<int> funcIndexOf = () =>
                    sqlDelete.IndexOf("=?", StringComparison.CurrentCulture);

                foreach (var item in nhLinqExpression.ParameterValuesByName)
                {
                    var valor = item.Value.Item1;

                    if (valor is string)
                        valor = "'" + valor + "'";

                    sqlDelete = sqlDelete
                        .Remove(funcIndexOf(), 2)
                        .Insert(funcIndexOf(), "=" + valor);
                }

                Console.WriteLine(sqlDelete);

                var xx3 = sessao.CreateSQLQuery(sqlDelete)
                    .ExecuteUpdate();

                Console.WriteLine(xx3);

                var query1 = sessao
                    .QueryOver<UsuarioFornecedor>()
                    .Where(condicao)
                 //.RootCriteria.Add(Restrictions.Where(condicao))                    
                 ;

                Console.WriteLine(query1);

                //sessao.Delete<UsuarioFornecedor>(o => o.Fornecedor.Id == 500);
                //sessao.Delete(null);

                //new LikeExpression("property", "%value%"))
                //System.Linq.Expressions.Expression.Compile().Invoke(entity)
                //condicao.Compile().Invoke(new UsuarioFornecedor());

                var x31 = sessao.CreateCriteria(typeof(UsuarioFornecedor))
                    .Add(Restrictions.Where(condicao))
                    .List();

                Console.WriteLine(x31);

                var x3 = sessao.CreateSQLQuery(string.Format("select * from UsuarioFornecedor where {0}", Restrictions.Where(condicao)))
                    .List();

                Console.WriteLine(x3);


                //UsuarioFornecedor


                //var query = Util.CriarQuery(condicao, sessao)
                //    .Count();


            }
        }