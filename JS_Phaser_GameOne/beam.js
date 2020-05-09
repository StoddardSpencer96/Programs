class Beam extends Phaser.GameObjects.Sprite {
    constructor(scene) {
        //reference the position of the player's ship
        var x = scene.player.x;
        var y = scene.player.y - 16;

        super(scene, x, y, "beam"); //call the super class
        scene.add.existing(this);

        this.play("beam_anim");
        scene.physics.world.enableBody(this);
        this.body.velocity.y = - 250;


        scene.projectiles.add(this);
    }

    //function to update the beam
    //if it reaches the top, then self destruct
    update() {
        if (this.y < 32) {
            this.destroy();
        }
    }
}