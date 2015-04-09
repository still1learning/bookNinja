/// <reference path="jquery-1.10.2.intellisense.js" />
/// <reference path="pixi.js" />

// setting up renderer
var renderer = new PIXI.CanvasRenderer(920, 640);
document.getElementById("display").appendChild(renderer.view);
//setting stage
var stage = new PIXI.Stage;

var Member = function (name, current, parrents, children) {
    this.x = 150;
    this.y = 150;
    this.name = name;
    this.current = current;
    this.parrents = parrents;
    this.children = children;
    this.drawn = false;
    var Member = this;
    this.Display = new PIXI.Text(Member.name, { font: "30px Galindo", fill: "#d6c069" });
    this.Display.position.x = Member.x;
    this.Display.position.y = Member.y;
    this.setPosition = function(x,y){
        Member.x=x;
        Member.y = y;
        Member.Display.position.x = x;
        Member.Display.position.y = y;
    }
}


var parrent1 = new Member("parent1", false, new Array(), new Array());
var parrent2 = new Member("parent2", false, new Array(), new Array());
var child1 = new Member("child1", false, new Array(), new Array());
var child2 = new Member("child2", false, new Array(), new Array());
var child3 = new Member("child3", false, new Array(), new Array());
var child4 = new Member("child4", false, new Array(), new Array());
var current = new Member("Darko", true, [parrent1, parrent2], [child1,child2,child3,child4]);
var Brother = new Member("Brother", false, [parrent1, parrent2], new Array());
var members = [parrent1, parrent2, child1, child2, child3, child4, current];
parrent1.children.push(current);
parrent2.children.push(current);
parrent1.children.push(Brother);
parrent2.children.push(Brother);
child1.parrents.push(current);
child2.parrents.push(current);
child3.parrents.push(current);
child4.parrents.push(current);
//current.children.push(child3);
//current.children.push(child2);
//current.children.push(child1);
//current.children.push(child4);

function DrawTree(current, x, y) {
    if (!current) return;
    if (current.drawn) return;
    else {
        if (current.parrents && current.parrents[0]&&current.parrents[0].children) {
            for (var i = 0 ; i < current.parrents[0].children.length; i++) {
                if (current.parrents[0].children[i].drawn && current.current) {
                    x = current.parrents[0].children[i] + 150;
                    console.log(current.name);
                }
            }
        }
        current.setPosition(x, y);
        stage.addChild(current.Display);
        current.drawn = true;
    }

    if (!!current.parrents) {
        for (var i = 0 ; i < current.parrents.length; i++) {
            DrawTree(current.parrents[i],current.x-100+i*200,y-100);
        }
    }
    
    if(!!current.children){
       var start = 60*(current.children.length*2 -1)/2;
        for (var i = 0; i < current.children.length; i++) {
            DrawTree(current.children[i], x - start +i*150, y + 100);
        }
    }
}


DrawTree(current, 400, 400);

requestAnimationFrame(animate);
function animate() {
    renderer.render(stage);
    requestAnimationFrame(animate);
}