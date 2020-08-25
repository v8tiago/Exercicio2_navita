# Gestão de Patrimônio
> Exercício número 2.

## Desenvolvimento

Este projeto foi desenvolvido em ASP.NET Core usando arquitetura MVC.
Foi utilizado a biblioteca do Identidy para gerenciar usuários do sistema.

## Funcionalidades

* Gerir os patrimônios
* Controle de acesso de usuários baseado em autorização e claims.

## Configurações

#### Acesso ao banco usando Pattern Repository

```bash
public interface "IRepository<TEntity>" : IDisposable where TEntity : Entity
```

#### Desacoplamento das entidades do modelo com as de apresentação usando AutoMapper
```bash
public AutoMapperConfig ()
{
   CreateMap<"Marca, MarcaViewModel">().ReverseMap();
   CreateMap<"Patrimonio, PatrimonioViewModel">().ReverseMap();
}
```


## Licença
O código desse projeto ainda não está licenciado.