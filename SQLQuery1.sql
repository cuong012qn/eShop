select * from Category
select * from Product
select * from ProductImage

select Category.Id, Category.Name, COUNT(Category.Name), Product.Name from Product 
join ProductCategory on Product.Id = ProductCategory.ProductId
join Category on Category.Id = ProductCategory.CategoryId
group by Category.Id

