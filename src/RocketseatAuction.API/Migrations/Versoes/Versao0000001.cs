using FluentMigrator;

namespace RocketseatAuction.API.Migrations.Versoes;

[Migration((long)NumeroVersoes.CriarTabelaAuction, "Cria tabela Auction")]
public class Versao0000001 : Migration
{

    public override void Down()
    {
    }

    public override void Up()
    {
        CriarTabelaUser();
        CriarTabelaItem();
        CriarTabelaOffer();
    }

    private void CriarTabelaUser()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("User"));

        tabela
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Email").AsString().NotNullable();
    }

    private void CriarTabelaItem()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("Items"));

        tabela
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Brand").AsString().NotNullable()
            .WithColumn("Condition").AsInt64().NotNullable()
            .WithColumn("BasePrice").AsDecimal().NotNullable()
            .WithColumn("AuctionId").AsInt64().NotNullable();

    }


    private void CriarTabelaOffer()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("Offer"));

        tabela
            .WithColumn("Price").AsString(100).NotNullable()
            .WithColumn("ItemId").AsInt64().NotNullable().ForeignKey("Fk_Offer_Items_Id", "Items", "Id")
            .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("Fk_Offer_User_Id", "User", "Id");
    }


}

