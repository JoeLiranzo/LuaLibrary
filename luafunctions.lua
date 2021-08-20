function GetNextBirdName()
    local maxValue = 0
    local nextBird = ""
    
    for  k,v in pairs(BIRDS.BIRDS) do
        local random = math.random(1, 100)
        local result = v["rarity"] * random

        if result > maxValue then
            maxValue = result
            nextBird = k
        end
    end

    return nextBird
end

--NextBirdGenerationTime in Seconds
function GetBirdGenerationTime()
    local birdGenerationTime = BIRD_GENERATION_TIME
    local birdGenerationMinTime = birdGenerationTime * EXTRAPOLATE_MIN_PERCENT
    local birdGenerationMaxTime = birdGenerationTime * EXTRAPOLATE_MAX_PERCENT

    birdGenerationMinTime = math.random(birdGenerationMinTime, birdGenerationMaxTime)

    return birdGenerationMinTime
end

function GetAmmoBulletsByLevel(type, level)
    local id = AMMO.AMMO[type].id
    level = tonumber(level)
    return AMMO.BULLETS[level][id]
end

function GetBirdDroppedItems()
    
end