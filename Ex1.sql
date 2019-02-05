/*
	Inserçao de dados nos tabelas do Exercicio 1
*/
declare @n int = 1;
declare @id int;
while @n <= 100
begin
	insert into clientes values (concat('José ', @id), '123.123.123-12', 'CPF');
	set @id = scope_identity();
	insert into Endereco values (@id, 'Av. Bady', 'Entrega');
	insert into Telefone values (@id, '(17) 9999-99999', 'Celular');
	set @n = @n + 1;	
end;