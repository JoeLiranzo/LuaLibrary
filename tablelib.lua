
---START CONSTANT VALUES---
PLAYER_SPEED = 2

BIRD_GENERATION_TIME = 3

EXTRAPOLATE_MIN_PERCENT = 0.75
EXTRAPOLATE_MAX_PERCENT = 1.25

-- BIRD_CAP_MIN_LERP_TIME = 1
-- BIRD_CAP_MAX_LERP_TIME = 2

---END CONSTANT VALUES---

---START TABLES---
BIRDS = {}
BIRDS.BIRDS = {
	SimpleBird  = {health = 125, rarity = 90, speed = 20},
	GreenBird   = {health = 150, rarity = 60, speed = 40},
	BlueBird    = {health = 200, rarity = 35, speed = 60},
	BlackBird   = {health = 250, rarity = 20, speed = 80},
}

--[[
	THE BULLETS CAN GET DIFFERENT EFFECTS
	THE BULLETS VALUES ARE THE DEFAULT VALUES OF START THE GAME.
]]--
AMMO = {}
AMMO.AMMO = {
	Bomb        = {id = 1, damage = 50,   rarity = 90, area = 0,   speed = 80},
	IceBomb     = {id = 2, damage = 60,   rarity = 90, area = 0,   speed = 80, effects = {slow = {duration = 2}}},
	PoisonBomb  = {id = 3, damage = 20,   rarity = 90, area = 0,   speed = 80, effects = {poison = {value = 10, duration = 5}}},
	TeleBomb    = {id = 4, damage = 40,   rarity = 90, area = 0,   speed = 80, effects = {poison = {value = 10, duration = 10}}},
	Inferno     = {id = 5, damage = 85,   rarity = 90, area = 15,  speed = 80},
	MegaBomb    = {id = 6, damage = 200,  rarity = 90, area = 60,  speed = 100},
}

AMMO.BULLETS = {
	--{Bomb = -1, IceBomb = 20, PoisonBomb = 20, TeleBomb = 5, Inferno = 800, MegaBomb = 1},	--Level 01
	{-1,		205,		205,		500,		200,		100},	--Level 01
	{-1,		50,			 35,		  7,		30,			  2},	--Level 02
}

ITEMS = {
	Egg		=	{minValue = 1, maxValue = 5},
	Bullet	= 	{minValue = 1, maxValue = 5}
}

EFFECTS =
{
	slow    = 0,
	poison  = 1
}

AMMO.EFFECTS = {
	POISON =  {damage = 15},
	ICE    =  {slow = 20}
}

BOSSES = {

}

function UnitTest()
	local ammoNames = {}

	for key, value in pairs(AMMO.AMMO) do
		table.insert(ammoNames, key)
		--print(key)
	end

	print(table.unpack(ammoNames))
	--print(ammoNames)
	--print(BIRDS["SimpleBird"]["speed"])
end

UnitTest()
































ME_EFFECTS = {
	["MAX_HP"]		        = 1,
	["MAX_SP"]		        = 2,
	["CON"]			        = 3,
	["INT"]			        = 4,
	["STR"]			        = 5,
	["DEX"]			        = 6,
	["ATT_SPEED"]		    = 7,
	["MOV_SPEED"]		    = 8,
	["CAST_SPEED"]		    = 9,
	["HP_REGEN"]		    = 10,
	["SP_REGEN"]		    = 11,
	["POISON_PCT"]		    = 12,
	["STUN_PCT"]		    = 13,
	["SLOW_PCT"]		    = 14,
	["CRITICAL_PCT"]	    = 15,
	["PENETRATE_PCT"]	    = 16,
	["ATTBONUS_HUMAN"]	    = 17,
	["ATTBONUS_ANIMAL"]	    = 18,
	["ATTBONUS_ORC"]	    = 19,
	["ATTBONUS_MILGYO"]	    = 20,
	["ATTBONUS_UNDEAD"]	    = 21,
	["ATTBONUS_DEVIL"]	    = 22,
	["STEAL_HP"]		    = 23,
	["STEAL_SP"]		    = 24,
	["MANA_BURN_PCT"]	    = 25,
	["DAMAGE_SP_RECOVER"]	= 26,
	["BLOCK"]		        = 27,
	["DODGE"]		        = 28,
	["RESIST_SWORD"]	    = 29,
	["RESIST_TWOHAND"]	    = 30,
	["RESIST_DAGGER"]	    = 31,
	["RESIST_BELL"]		    = 32,
	["RESIST_FAN"]		    = 33,
	["RESIST_BOW"]		    = 34,
	["RESIST_FIRE"]		    = 35,
	["RESIST_ELEC"]		    = 36,
	["RESIST_MAGIC"]	    = 37,
	["RESIST_WIND"]		    = 38,
	["REFLECT_MELEE"]	    = 39,
	["REFLECT_CURSE"]	    = 40,
	["POISON_REDUCE"]	    = 41,
	["KILL_SP_RECOVER"]	    = 42,
	["EXP_DOUBLE_BONUS"]	= 43,
	["GOLD_DOUBLE_BONUS"]	= 44,
	["ITEM_DROP_BONUS"]	    = 45,
	["POTION_BONUS"]	    = 46,
	["KILL_HP_RECOVER"]	    = 47,
	["IMMUNE_STUN"]		    = 48,
	["IMMUNE_SLOW"]		    = 49,
	["IMMUNE_FALL"]		    = 50,
	["SKILL"]		        = 51,
	["BOW_DISTANCE"]	    = 52,
	["ATT_GRADE_BONUS"]	    = 53,
	["DEF_GRADE_BONUS"]	    = 54,
	["MAGIC_ATT_GRADE"]	    = 55,
	["MAGIC_DEF_GRADE"]	    = 56,
	["CURSE_PCT"]		    = 57,
	["MAX_STAMINA"]		    = 58,
	["ATTBONUS_WARRIOR"]	= 59,
	["ATTBONUS_ASSASSIN"]	= 60,
	["ATTBONUS_SURA"]	    = 61,
	["ATTBONUS_SHAMAN"]	    = 62,
	["ATTBONUS_MONSTER"]	= 63,
}



BOSSES = {

}

--[[
SimpleBird  = {health = 200, rarity = 90, velocity = 20},
GreenBird   = {health = 150, rarity = 60, velocity = 40},
BlueBird    = {health = 125, rarity = 35, velocity = 60},
BlackBird   = {health = 100, rarity = 20, velocity = 80},
]]--

--FAST TEST
--[[
SimpleBird  = {health = 200, rarity = 100, velocity = 80},
GreenBird   = {health = 150, rarity = 100, velocity = 80},
BlueBird    = {health = 125, rarity = 100, velocity = 80},
BlackBird   = {health = 100, rarity = 100, velocity = 80},
]]--

---END TABLES---


-- [0]   = {name="SimpleBird", attack = 10, health = 100, rarity = 90, velocity= 2},
-- [1]   = {name="GreenBird", attack = 15, health = 125, rarity = 60, velocity= 4},
-- [2]   = {name="BlueBird" , attack = 20, health = 150, rarity = 35, velocity= 6},
-- [3]   = {name="BlackBird", attack = 25, health = 200, rarity = 20, velocity= 9},


-- ["SimpleBird"]  = {id = 1, attack = 10, health = 100, rarity = 90, velocity= 2},
-- ["GreenBird"]   = {id = 2, attack = 15, health = 125, rarity = 60, velocity= 4},
-- ["BlueBird"]    = {id = 3, attack = 20, health = 150, rarity = 35, velocity= 6},
-- ["BlackBird"]   = {id = 4, attack = 25, health = 200, rarity = 20, velocity= 9},
