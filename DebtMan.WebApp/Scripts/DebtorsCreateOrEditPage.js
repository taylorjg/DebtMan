var DebtorsCreateOrEditPageSystem = {

    init: function () {

        $(".addDebtRow").click(function () {
            var debtsTable = $("#debtsTable");
            var debtsTableRowTemplate = $("#debtsTableRowTemplate");
            debtsTable.append(debtsTableRowTemplate.clone());
            DebtorsCreateOrEditPageSystem.renumberDebtsTableRows();
        });

        $(".deleteDebtRow").live("click", function () {
            var row = $(this).closest("tr");
            row.remove();
            DebtorsCreateOrEditPageSystem.renumberDebtsTableRows();
        });
    },

    renumberDebtsTableRows: function () {
        
        var debtsTable = $("#debtsTable");
        var rows = debtsTable.find("tr").not("#tableHeader");

        var index = 0;
        
        rows.each(function () {

            var inputElement = $(this).find("input");
            var spanElement = $(this).find("span");

            // name="Debts[4].AmountOwed"
            // id="Debts_4__AmountOwed" (same as name with non-word characters replaced with an underscore)
            // data-valmsg-for="Debts[4].AmountOwed" (same as name)
            var nameAttr = "Debts[" + index + "].AmountOwed";
            var idAttr = nameAttr.replace(/\W/g, "_");

            inputElement.attr("id", idAttr);
            inputElement.attr("name", nameAttr);
            spanElement.attr("data-valmsg-for", nameAttr);

            index++;
        });
    }
};

jQuery(document).ready(function () {
    DebtorsCreateOrEditPageSystem.init();
});
