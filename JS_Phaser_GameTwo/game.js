const config = {
  type: Phaser.AUTO,
  parent: 'game',
  width: 800,
  heigth: 640,
  scale: {
    mode: Phaser.Scale.RESIZE,
    autoCenter: Phaser.Scale.CENTER_BOTH
  },
  scene: {
    preload,
    create,
    update,
  },
  physics: {
    default: 'arcade',
    arcade: {
      gravity: { y: 500 },
      debug: false,
    },
  }
};

const game = new Phaser.Game(config);

//function that loads up the objects that will be used in the game
function preload() { 
  this.load.image('background', 'assets/images/background.png'); //loads up the background
  this.load.image('spike', 'assets/images/spike.png'); //loads up the spikes
  // At last image must be loaded with its JSON
  this.load.atlas('player', 'assets/images/kenney_player.png','assets/images/kenney_player_atlas.json');
  this.load.image('tiles', 'assets/tilesets/platformPack_tilesheet.png'); //loads up the tile sheet
  // Load the export Tiled JSON
  this.load.tilemapTiledJSON('map', 'assets/tilemaps/level1.json');

}

//function to create all of the necessary objects
function create() {
  //create the background image for the game
  const backgroundImage = this.add.image(0, 0,'background').setOrigin(0, 0);
  backgroundImage.setScale(2, 0.8);
  
  //create the map for the game
  const map = this.make.tilemap({ key: 'map' });

  //create the tile set for the game
  //first parameter: name of the JSON file
  //second parameter: name of the file name used in the preload function
  const tileset = map.addTilesetImage('kenny_simple_platformer', 'tiles');

  //create the platform layer for the game
  const platforms = map.createStaticLayer('Platforms', tileset, 0, 200);

  platforms.setCollisionByExclusion(-1, true);

  //create the player for the game
  this.player = this.physics.add.sprite(50, 300, 'player'); //'player' = name of file containing the sprite
  this.player.setBounce(0.1); //set the bounce rate
  this.player.setCollideWorldBounds(true);
  this.physics.add.collider(this.player, platforms);
  
  //create the animation for the player whenever it's walking
  this.anims.create({
    key: 'walk',
    frames: this.anims.generateFrameNames('player', {
      prefix: 'robo_player_',
      start: 2,
      end: 3,
    }),
    frameRate: 10,
    repeat: -1
  });

  //create the animation for the player whenever it's idle
  this.anims.create({
    key: 'idle',
    frames: [{ key: 'player', frame: 'robo_player_0' }],
    frameRate: 10,
  });

  //create the animation for the player whenever it jumps
  this.anims.create({
    key: 'jump',
    frames: [{ key: 'player', frame: 'robo_player_1' }],
    frameRate: 10,
  });
  
  //enable cursor keys so that we can move the player using the keyboard
  this.cursors = this.input.keyboard.createCursorKeys();

  
  // Create the spikes
  // sprites in the group don't move via gravity or by player collisions
  this.spikes = this.physics.add.group({
    allowGravity: false,
    immovable: true
  });

  // Let's get the spike objects- NOTE: these are NOT sprites
  const spikeObjects = map.getObjectLayer('Spikes')['objects'];

  // Now we create the spikes in our sprite group for each object in our map
  //This is done using a foreach loop
  spikeObjects.forEach(spikeObject => {
    const spike = this.spikes.create(spikeObject.x, spikeObject.y + 200 - spikeObject.height, 'spike').setOrigin(0, 0);
    spike.body.setSize(spike.width, spike.height - 20).setOffset(0, 20);
  });

  //Create the reset position when the player hits the spike
  //this will make the call to the playerHit function
  this.physics.add.collider(this.player, this.spikes, playerHit, null, this);
 }

//function to update anything necessary in the game
function update() { 
  // Control the player with left or right keys
  //if the player goes left and the player is on the floor, 
  //set the velocity, and indicate that the walking will happen
  //else if the player goes right and the player is on the floor,
  //set the velocity and indicatee that the walking will happen
  if (this.cursors.left.isDown) {
    this.player.setVelocityX(-200);
    if (this.player.body.onFloor()) {
      this.player.play('walk', true);
    }
  } else if (this.cursors.right.isDown) {
    this.player.setVelocityX(200);
    if (this.player.body.onFloor()) {
      this.player.play('walk', true);
    }
  } else {
    // If no keys are pressed, the player keeps still
    //Because the player is stationary, it will have no velocity
    this.player.setVelocityX(0);
    // Only show the idle animation if the player is footed
    // If this is not included, the player would look idle while jumping
    if (this.player.body.onFloor()) {
      this.player.play('idle', true);
    }
  }

  // Player can jump while walking any direction by pressing the space bar
  // or the 'UP' arrow
  if ((this.cursors.space.isDown || this.cursors.up.isDown) && this.player.body.onFloor()) {
    this.player.setVelocityY(-350);
    this.player.play('jump', true);
  }

  if (this.player.body.velocity.x > 0) {
    this.player.setFlipX(false);
  } else if (this.player.body.velocity.x < 0) {
    // otherwise, make them face the other side
    this.player.setFlipX(true);
  }
}

//function to create any instance when a player hits a spike
function playerHit(player, spike) {
  player.setVelocity(0, 0);
  player.setX(50);
  player.setY(300);
  player.play('idle', true);
  player.setAlpha(0);
  let tw = this.tweens.add({
    targets: player,
    alpha: 1,
    duration: 100,
    ease: 'Linear',
    repeat: 5,
  });
}