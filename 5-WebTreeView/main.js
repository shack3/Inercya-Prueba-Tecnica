(async () => {
    const rec = (childs, s) => {
        if (childs.Children.length === 0)
            s += `<li>${childs.Name}</li>`;
        else {
            s += `<li><span>${childs.Name}</span><ul>`;

            for (let i = 0; i < childs.Children.length; i++)
                s = rec(childs.Children[i], s);

            s += '</li></ul>';
        }

        return s;
    }


    let child = await fetch('./Items.json');

    child = await child.json()

    let u = "";
    for (let i = 0; i < child.length; i++)
        u += `<ul>${rec(child[i], "")}</ul>`;

    document.getElementById("app").innerHTML = u;
})();

