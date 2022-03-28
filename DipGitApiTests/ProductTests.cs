using System;
using DipGitApiLib;
using System.Collections.Generic;
using Xunit;


namespace DipGitApiTests
{
    public class ProductTests
    {
        Products ProductTestList1;
        Products ProductTestList2;
        Product newProduct;
    

        //name,price,qty string float int

        public ProductTests(){
            this.ProductTestList1 = new Products();
            this.ProductTestList1.ProductList = new List<Product>();
            this.ProductTestList1.ProductList.Add(new Product ("Toilet Paper", 15, 400));
            this.ProductTestList1.ProductList.Add(new Product ("LEGOS", 10, 450));
            this.ProductTestList1.ProductList.Add(new Product ("Tooth Paste", 3, 500));
            this.ProductTestList1.ProductList.Add(new Product ("Gummies", 7, 275));
            this.ProductTestList1.ProductList.Add(new Product ("Rubix", 5, 148));


            this.ProductTestList2 = new Products();
            this.ProductTestList2.ProductList = new List<Product>();
            this.ProductTestList2.ProductList.Add(new Product ("Toilet Paper", 15, 400));
            this.ProductTestList2.ProductList.Add(new Product ("LEGOS", 10, 450));
            this.ProductTestList2.ProductList.Add(new Product ("Tooth Paste", 3, 500));
    }

    [Fact]
    public void GetTotalQtyProductsTest(){
        int totalqty = 0;
        totalqty = this.ProductTestList1.ProductList[0].Qty + this.ProductTestList1.ProductList[1].Qty + this.ProductTestList1.ProductList[2].Qty + this.ProductTestList1.ProductList[3].Qty + this.ProductTestList1.ProductList[4].Qty;
        Assert.Equal(totalqty, 1773);
    }

    [Fact]
    public void GetTotalQtyProductsTest2(){            
        int totalqty2 = 0;
        totalqty2 = this.ProductTestList2.ProductList[0].Qty + this.ProductTestList2.ProductList[1].Qty + this.ProductTestList2.ProductList[2].Qty;
        Assert.Equal(totalqty2, 1350);
    }

    [Fact]
    public void GetTotalQtyProductsTest2Fail(){            
        int totalqty2 = 0;
        totalqty2 = this.ProductTestList2.ProductList[0].Qty + this.ProductTestList2.ProductList[1].Qty + this.ProductTestList2.ProductList[2].Qty;
            Assert.Equal(totalqty2, 2741);
    }
    [Fact]

    public void GetTotalValueProductsTest(){
        float totalvalue = 0;
        totalvalue = this.ProductTestList1.ProductList[0].Price + this.ProductTestList1.ProductList[1].Price + this.ProductTestList1.ProductList[2].Price + this.ProductTestList1.ProductList[3].Price + this.ProductTestList1.ProductList[4].Price;
        Assert.Equal(totalvalue, 40);
    }
}
}
