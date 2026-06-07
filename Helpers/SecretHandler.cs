using System.Collections.Generic;
using System.Linq;
using CarQuestAP.Archipelago;

namespace CarQuestAP.Helpers {
    public static class SecretHandler {
        private static Dictionary<string, List<string>> hubSecretMapping = new Dictionary<string, List<string>>() {
            //Hub
            {"Hub: Start Room Blocker",                      ["wall01"]},
            {"Hub: Simple Portal Bridge Wall",               ["bridgewall"]},
            {"Hub: North Pool Small Secret Door",            ["poolfardoor"]},
            {"Hub: North Pool Jump Ramp",                    ["pieceramptop"]},
            {"Hub: South Pool Artifact Block",               ["sculpturecover"]},
            {"Hub: Upper University Alleyway Access",        ["cornerramp"]},
            {"Hub: South Pool Deadend Door",                 ["leftshortwall"]},
            {"Hub: Tree Slalom Unlock",                      ["slalomtrees"]},
            {"Hub: Museum Unlock",                           ["museumramp"]},
            {"Hub: North Pool Portal Access",                ["sidebridge"]},
            {"Hub: Cube Monument Access",                    ["blockspinwall"]},
            {"Hub: South Portal Ramp Door",                  ["shortwall"]},
            {"Hub: North Pool Vault Door",                   ["vaultdoor"]},
            {"Hub: South Portal Secondary Ramp",             ["backbridgeramp"]},
            {"Hub: South Portal Bridge",                     ["backbridge"]},
            {"Hub: Pool Drain Door",                         ["drain"]},
            {"Hub: Progressive Pool",                        ["pool", "poolrefill"]},
            {"Hub: Start Room Right Door",                   ["bigwall"]},
            {"Hub: Pool Push Block",                         ["movablelock"]},
            {"Hub: Pool South East Blocker",                 ["pooltopper01"]},
            {"Hub: Pool North West Blocker",                 ["pooltopper02"]},
            {"Hub: Pool Vault Portal Unlock",                ["vaultinnerdoor"]},
            {"Hub: Throne Exterior Wall",                    ["blockfall"]},
            {"Hub: Start Room Bridge",                       ["wall02"]},
            {"Hub: Central Bridge East Ramp",                ["toprightramp"]},
            {"Hub: Exterior University Ramp",                ["chip"]},
            {"Hub: Central Bridge West Ramp",                ["topleftramp"]},
            {"Hub: Pool North East Blocker",                 ["blocktop"]},
            {"Hub: Central Bridge Portal Bridge",            ["distantbridge"]},
            {"Hub: Exterior University Wall Door",           ["uniwall"]},
            {"Hub: Ramp Near Simple Portal",                 ["narrowbridge"]},
            {"Hub: Secondary Universiy Wall Door",           ["backramp"]},
            {"Hub: Blocker Near Whale Bridge",               ["raiseblock"]},
            {"Hub: Whale Bridge",                            ["whalebridge"]},
            {"Hub: Colloseum Bridge",                        ["arenabridge"]},
            {"Hub: Colloseum Podium Extension",              ["arenaextension"]},
            {"Hub: Start Area Back Removal",                 ["backjump"]},
            {"Hub: Colloseum Exterior Wall Doors",           ["arenaentrance"]},
            {"Hub: Colloseum Push Block Unlock",             ["arenaramps"]},
            {"Hub: Colloseum Podium Door",                   ["arenablocker"]},
            {"Hub: Colloseum Podium Ramp",                   ["arenabigramp"]},
            {"Hub: Ramp to Light Puzzle",                    ["cornerwall"]},
            {"Hub: Top Path Floating Islands",               ["singlefloatingrock"]},
            {"Hub: Start Outlook Dead End Door",             ["deadendwall"]},
            {"Hub: Bottom Path Floating Islands",            ["floatingrocks"]},
            {"Hub: Lookout Long Path Door",                  ["ledgebridge"]},
            {"Hub: Whales and Central Dead End Door",        ["anotherdeadendwall"]},
            {"Hub: Start Lookout Door",                      ["frontledge"]},
            {"Hub: University Doors",                        ["templedoor"]},
            {"Hub: University Back Row Ramp",                ["uniramp"]},
            {"Hub: University Lower Second Row Ramp",        ["unichair"]},
            {"Hub: University Lower Third Row Ramp",         ["unichair2"]},
            {"Hub: University Lower Fourth Row Ramp",        ["unichair3"]},
            {"Hub: University Lower Push Ramp",              ["unimovableramp"]},
            {"Hub: University Lower Back Artifact Platform", ["unibackramp"]},
            {"Hub: University Second Floor Ramp",            ["templeramp"]},
            {"Hub: Upper Bridge Jump Walls",                 ["jumpwall"]},
            {"Hub: Tree Area Door",                          ["treewall"]},
            {"Hub: University Portal Buttons",               ["unijunk"]},
            {"Hub: Throne Room Door",                        ["upperdoor"]},
            {"Hub: Power Room South Door",                   ["threewaywall"]},
            {"Hub: University Portal Planetarium Access",    ["uniportalupgrade"]},
            {"Hub: Power Room North Door",                   ["threewallrun"]},
            {"Hub: World Peace",                             ["brickbristles"]},

            // Hub Museum
            {"Hub: Sun Museum Glass",                        ["stainedglass01"]},
            {"Hub: Block Museum Glass",                      ["stainedglass03"]},
            {"Hub: Book Museum Glass",                       ["stainedglass08"]},
            {"Hub: Energy Cell Museum Glass",                ["stainedglass05"]},
            {"Hub: Tire Museum Glass",                       ["stainedglass02"]},
            {"Hub: Blockstar Museum Glass",                  ["stainedglass10"]},
            {"Hub: Tree Museum Glass",                       ["stainedglass04"]},
            {"Hub: Cube Museum Glass",                       ["stainedglass09"]},
            {"Hub: Portal Museum Glass",                     ["stainedglass06"]},
            {"Hub: Brick Bristles Museum Glass",             ["stainedglass07"]},

            // Simple
            {"Simple: Exit Bridge",                          ["exitramp"]},

            // Cubes
            {"Cubes: Exit Bridge",                           ["blockspinplatform"]},

            // Desert
            {"Desert: South West Mound",                     ["mesaramp"]},
            {"Desert: Shop Cave Door",                       ["cavedoor"]},
            {"Desert: North West Mound",                     ["mesaplatfor"]},
            {"Desert: South East Mound",                     ["mesa"]},
            {"Desert: Fixit Shop Door",                      ["fixitdoor"]},
            {"Desert: Fixit Shop Fence",                     ["fence"]},
            {"Desert: Exit Ramp",                            ["portalramp"]},

            // Slider
            {"Slider: Start Ramp",                           ["sliderramp"]},
            {"Slider: Left Push Block Unlock",               ["pushleft"]},
            {"Slider: Right Push Block Unlock",              ["pushright"]},
            {"Slider: Left Side Ramp",                       ["sliderbigramp"]},
            {"Slider: Exit Ramp Unlock",                     ["sliderstopper"]},

            // Maze
            {"Maze: Door to Big Ramp",                       ["mazewall"]},
            {"Maze: Hedge Ramp",                             ["mazeramp"]},
            {"Maze: Raise Cave Wall",                        ["mazebridge"]},
            {"Maze: Lower Artifact Wall",                    ["mazedoor"]},
            {"Maze: Interior Wall Bridge",                   ["mazeblock"]},
            {"Maze: Exit Door",                              ["endmazebridge"]},

            // Glass
            {"Glass Box: Useless Block",                    ["firstplatform"]},
            {"Glass Box: Exit Bridge",                      ["secondplatform"]},

            // Sands
            {"Sands: Exterior Walls Access",                ["upramp"]},
            {"Sands: Lower South West Tower",               ["towera"]},
            {"Sands: Lower Exterior Wall Tower",            ["cornertower"]},
            {"Sands: South East Tower Access",              ["towerd"]},
            {"Sands: Move Fallen Tower Roof",               ["towerc"]},
            {"Sands: Raise Exit Platform",                  ["towerportal"]},
            {"Sands: North East Door",                      ["cornertowerdoor"]},
            {"Sands: Reveal King Artifact",                 ["stonehead"]},
            {"Sands: Exit Reward Reveal",                   ["toplid"]},
            {"Sands: Lower North West Tower",               ["towerb"]},

            // Ocean
            {"Ocean: Vulcano Slope",                        ["seamesaramp"]},
            {"Ocean: Fort Bottom Ramp",                     ["volcanoramp"]},
            {"Ocean: Fort Middle Ramp",                     ["lookoutramp"]},
            {"Ocean: Raise Hill Near Exit",                 ["lookoutgaps"]},
            {"Ocean: Fort Top Ramp",                        ["smallsearamp"]},
            {"Ocean: Raise Fish Ring Rock",                 ["lookoutsinglegap"]},
            {"Ocean: Raise Fish Ring Ramp",                 ["seapinnacle"]},
            {"Ocean: Pirate Ship Repair",                   ["anchor"]},
            {"Ocean: Shoot Cannon",                         ["canon"]},
            {"Ocean: Ring Bell",                            ["bell"]},

            // Ice Temple
            {"Ice: West Artifact Blocker",                  ["templehighblocker"]},
            {"Ice: South Ramp Blocker",                     ["templelowlocker"]},
            {"Ice: Secondary Wall Ramp",                    ["hugelongramp"]},
            {"Ice: Ice Pillar Blocker",                     ["sliderclamp"]},
            {"Ice: Perimeter Wall Blocker",                 ["walkwayblocker"]},
            {"Ice: South Jump Path Wall",                   ["templesimpleblocker"]},
            {"Ice: South Wall Bridge",                      ["longtowerbridge"]},
            {"Ice: Other Wall Bridges",                     ["triplebridge"]},
            {"Ice: Wall Jump Ramp",                         ["templehighramp"]},
            {"Ice: Wall Bridge Ramp to Monument",           ["bentbridge"]},
            {"Ice: Raise North East Tower",                 ["templetop"]},

            // Sheep
            {"Sheep: Shed Ramp",                            ["sheepramp"]},
            {"Sheep: Sheep Shed Door",                      ["sheeppendoor"]},
            {"Sheep: Windmill Activation",                  ["windmilldoor"]},
            {"Sheep: Raise Shed",                           ["sheeppen"]},
            {"Sheep: Raised Shed Hidden Wall",              ["sheephiddendoor"]},

            // Island
            {"Island: East Long Path Start Wall",            ["seawayblock"]},
            {"Island: Artifact Blocker Under East Path",     ["underseabridge"]},
            {"Island: First East Path Bridge",               ["seawalkway01"]},
            {"Island: Lower Jump Blocker Behind Start",      ["plankblocker"]},
            {"Island: Lower South East Triangle Island",     ["seacornerramp"]},
            {"Island: Second East Path Bridge",              ["seawalkway02"]},
            {"Island: East Path Ocean Ramp",                 ["seaarchramp"]},
            {"Island: Third East Path Bridge",               ["seawalkway03"]},
            {"Island: Night Portal",                         ["timedoor"]},
            {"Island: West Shark Island Ramp",               ["searockhill"]},
            {"Island: West Island Artifact Ramp",            ["seasideramp"]},
            {"Island: East Ledge Artifact Ramp",             ["caveblockerchip"]},
            {"Island: South Path Artifact Jump Ramp",        ["longsearamp"]},
            {"Island: East Ledge Cave Entrance",             ["seahole"]},
            {"Island: South Path Cave Entrance",             ["rockholedoor"]},
            {"Island: Open Clam",                            ["clam"]},
            {"Island: Shark Pinnacle",                       ["waterpinnacle"]},
            {"Island: North Lower Wall Ramp",                ["leftsearamp"]},
            {"Island: East Path Raft Cave Door",             ["raftdoorblocker"]},
            {"Island: North Upper Wall Ramp",                ["rightsearamp"]},
            {"Island: Lower Serpant Hump",                   ["seamonsterhump"]},
            {"Island: South Path Cave Wall Removal",         ["raftblocker"]},
            {"Island: Lower Serpant Head",                   ["seamonsterhead"]},
            {"Island: Lower Spiral Island",                  ["plaque"]},
            {"Island: Pond Treetop Ramp",                    ["treeramp"]},
            {"Island: Serpant head Jump Ramp",               ["seamonsterheadramp"]},
            {"Island: Hut Entrance Ramp",                    ["hutblocker"]},
            {"Island: East Ocean Jump Ramp",                 ["seablocktop"]},
            {"Island: Hut Treetop Ramp",                     ["huttreeway"]},
            {"Island: Treetop West Bridge",                  ["treeway"]},
            {"Island: Pond Drain",                           ["treeponddrain"]},
            {"Island: Pond Treetop Ramp Blocker",            ["uppertreeblocker"]},
            {"Island: Open Hut Door",                        ["hutdoor"]},
            {"Island: Exit Ramp",                            ["islandexitramp"]},

            // Throne
            {"Throne: Interior South West Ramp",            ["throneleftramp"]},
            {"Throne: Interior South East Ramp",            ["thronerightramp"]},
            {"Throne: Open North Windows",                  ["thronewindow01"]},
            {"Throne: Open South Windows",                  ["thronewindow06"]},
            {"Throne: Open Main Door",                      ["thronedoorramp"]},
            {"Throne: Main Door Ramp",                      ["thronedoor"]},
            {"Throne: West Middle Window",                  ["thronewindow02"]},
            {"Throne: West Push Ramp",                      ["thronerightblocker"]},
            {"Throne: East Middle Window",                  ["throneleftblocker"]},
            {"Throne: East Push Ramp",                      ["thronewindow03"]},
            {"Throne: West South Window",                   ["thronewindow04"]},
            {"Throne: East South Window",                   ["thronewindow05"]},
            {"Throne: East Exterior Wall",                  ["thronerightdoor"]},
            {"Throne: West Exterior Wall",                  ["throneleftdoor"]},
            {"Throne: Lower High Garden Exit Ledge",        ["throneportalbridge"]},
            {"Throne: North Throne Hidden Door",            ["thronebackcover"]},
            {"Throne: Throne Ramp",                         ["throneramp"]},
            {"Throne: Exit Portal",                         ["throneportalopen"]},

            // Planetarium
            {"Planetarium: Elevator Access",                ["planetariumblock"]},

            // Power Room
            {"Power Room: Green Cable Push",                ["greenblocker"]},
            {"Power Room: Green Cable Activate",            ["greencable"]},
            {"Power Room: Blue Cable Push",                 ["blueblocker"]},
            {"Power Room: Blue Cable Activate",             ["bluecable"]},
            {"Power Room: Red Cable Push",                  ["redblocker"]},
            {"Power Room: Red Cable Activate",              ["redcable"]},
            {"Power Room: Yellow Cable Push",               ["yellowblocker"]},
            {"Power Room: Yellow Cable Activate",           ["yellowcable"]},
            {"Hub: Power Restore",                          ["yellowbook"]},
            {"Power Room: Exit Teleporter",                 ["cbb"]},

            // Limbo
            {"Limbo: Crown and Exit Portal", ["yellowcrown"]},
        };

        private static Dictionary<string, string> locationMapping = new Dictionary<string, string>() {
            //Hub
            {"wall01",               "Hub: Starting Area Artifact"},
            {"poolfardoor",          "Hub: University Alleyway Artifact"},
            {"pieceramptop",         "Hub: North Pool Secret Door Artifact"},
            {"sculpturecover",       "Hub: North Pool Jump Ramp"},
            {"cornerramp",           "Hub: Tree Slalom Start Artifact"},
            {"leftshortwall",        "Hub: Upper University Alleyway Artifact"},
            {"slalomtrees",          "Hub: South Pool Dead End Artifact"},
            {"museumramp",           "Hub: Tree Slalom Reward Artifact"},
            {"sidebridge",           "Hub: Museum Artifact"},
            {"shortwall",            "Hub: Cube Monument Artifact"},
            {"vaultdoor",            "Hub: Ramp Near South Portal Artifact"},
            {"backbridgeramp",       "Hub: North Pool Vault Room Artifact"},
            {"backbridge",           "Hub: Inside Ramp Near South Portal Artifact"},
            {"pool",                 "Hub: Pool Drain Artifact"},
            {"bigwall",              "Hub: Drained Pool Jump Artifact"},
            {"movablelock",          "Hub: Throne Exterior Near Museum Piece Artifact"},
            {"pooltopper01",         "Hub: Pool South West Artifact"},
            {"pooltopper02",         "Hub: Pool South East Artifact"},
            {"vaultinnerdoor",       "Hub: Pool North West Artifact"},
            {"blockfall",            "Hub: Pool Center Artifact"},
            {"wall02",               "Hub: Throne Exterior Artifact"},
            {"toprightramp",         "Hub: Lookout Artifact"},
            {"chip",                 "Hub: Central Bridge East Ramp Artifact"},
            {"topleftramp",          "Hub: University Exterior Artifact"},
            {"blocktop",             "Hub: Central Bridge West Ramp Artifact"},
            {"distantbridge",        "Hub: Pool North East Artifact"},
            {"narrowbridge",         "Hub: Alley Push Ramp Artifact"},
            {"backramp",             "Hub: Upper Alley Bridge Near Throne Artifact"},
            {"raiseblock",           "Hub: Lower Artifact Near Whale Bridge"},
            {"whalebridge",          "Hub: Upper Artifact Near Whale Bridge"},
            {"arenabridge",          "Hub: Whale Bridge Artifact"},
            {"arenaextension",       "Hub: Colloseum Hidden in Push Block Artifact"},
            {"backjump",             "Hub: Colloseum Podeum Artifact"},
            {"arenaentrance",        "Hub: Start Area Jump Artifact"},
            {"arenaramps",           "Hub: Behind Colloseum Artifact"},
            {"arenablocker",         "Hub: Near Rich Portal Artifact"},
            {"arenabigramp",         "Hub: Inside Podeum Artifact"},
            {"singlefloatingrock",   "Hub: Upper Light Puzzle Artifact"},
            {"deadendwall",          "Hub: Floating Island Artifact"},
            {"floatingrocks",        "Hub: Upper Pool Dead End Path Artifact"},
            {"anotherdeadendwall",   "Hub: Long Lookout Alley Artifact"},
            {"frontledge",           "Hub: Central Path Dead End Artifact"},
            {"templedoor",           "Hub: Start Lookout Artifact"},
            {"uniramp",              "Hub: University Podium Artifact"},
            {"unichair",             "Hub: University Back Right Artifact"},
            {"unichair2",            "Hub: University Second Row Artifact"},
            {"unichair3",            "Hub: University Third Row Artifact"},
            {"unimovableramp",       "Hub: University Fourth Row Artifact"},
            {"unibackramp",          "Hub: University First Row Artifact"},
            {"templeramp",           "Hub: University Back Left Artifact"},
            {"jumpwall",             "Hub: Behind University Portal Artifact"},
            {"uniportalupgrade",     "Hub: Power Room Entry Artifact"},

            {"stainedglass01",       "Hub: Throne Exterior Museum Piece"},
            {"stainedglass03",       "Hub: Ice Portal Drop Ledge Museum Piece"},
            {"stainedglass05",       "Hub: Hopscotch Museum Piece"},
            {"stainedglass02",       "Hub: South Pool Jump Museum Piece"},
            {"stainedglass10",       "Hub: Colloseum Museum Piece"},
            {"stainedglass06",       "Hub: Teleport Islands Museum Piece"},

            // Simple
            {"exitramp",             "Simple: Artifact Under Mound"},
            {"bridgewall",           "Simple: Artifact On Exit Ramp"},

            // Cubes
            {"blockspinplatform",    "Cubes: Artifact Behind Start"},
            {"blockspinwall",        "Cubes: Artifact On Exit Ramp"},

            // Fixit
            {"mesaramp",             "Desert: North East Mound Artifact"},
            {"cavedoor",             "Desert: South West Mound Artifact"},
            {"mesaplatform",         "Desert: Shop Cave Artifact"},
            {"mesa",                 "Desert: North West Mound Artifact"},
            {"fixitdoor",            "Desert: South East Mound Artifact"},
            {"fence",                "Desert: Fixit Shop Interior Artifact"},
            {"portalramp",           "Desert: Fixit Shop Fence Artifact"},
            {"drain",                "Desert: Exit Reward Artifact"},

            // Slider
            {"sliderramp",          "Slider: Front Right Artifact"},
            {"pushleft",            "Slider: Lower Back Artifact"},
            {"pushright",           "Slider: Upper Left Artifact"},
            {"sliderbigramp",       "Slider: Upper Right Artifact"},
            {"sliderstopper",       "Slider: Upper Upper Left Artifact"},
            {"poolrefill",          "Slider: Exit Reward Artifact"},

            // Maze
            {"mazewall",            "Maze: First Artifact"},
            {"mazeramp",            "Maze: On Wall Near Start Artifact"},
            {"mazebridge",          "Maze: Cave Artifact"},
            {"mazedoor",            "Maze: Top of Mini Maze Artifact"},
            {"mazeblock",           "Maze: Hidden Drop Off Artifact"},
            {"endmazebridge",       "Maze: On Wall Near Exit Artifact"},
            {"uniwall",             "Maze: Exit Reward Artifact"},

            // Glass
            {"firstplatform",       "Glass Cube: Top Artifact"},
            {"secondplatform",      "Glass Cube: Bottom Artifact"},
            {"cornerwall",          "Glass Cube: Exit Reward"},

            // Sands
            {"upramp",              "Sands: Artifact Under South East Roof"},
            {"towera",              "Sands: Exterior Wall Artifact"},
            {"cornertower",         "Sands: South West Tower Artifact"},
            {"towerd",              "Sands: Exterior Wall Tower Artifact"},
            {"towerc",              "Sands: Artifact Inside South East Tower"},
            {"towerb",              "Sands: Artifact Under Fallen Tower Roof"},
            {"towerportal",         "Sands: North West Tower Roof Artifact"},
            {"cornertowerdoor",     "Sands: Artifact Under South West Roof"},
            {"stonehead",           "Sands: North East Door Artifact"},
            {"toplid",              "Sands: King Head Artifact"},
            {"viewwall",            "Sands: Exit Reward Artifact"},

            // Whales
            {"seamesaramp",         "Ocean: Shipwreck Artifact"},
            {"volcanoramp",         "Ocean: Top of Vulcano Artifact"},
            {"lookoutramp",         "Ocean: Outer Fort Bottom Artifact"},
            {"lookoutgaps",         "Ocean: Outer Fort Middle Artifact"},
            {"smallsearamp",        "Ocean: Hill Near Portal Artifact"},
            {"lookoutsinglegap",    "Ocean: Artifact Near Bell"},
            {"seapinnacle",         "Ocean: Inside Fort Artifact"},
            {"anchor",              "Ocean: Fish Circle Jump Artifact"},
            {"canon",               "Ocean: Inside Pirate Ship Artifact"},
            {"bell",                "Ocean: Inside Vulcano Artifact"},
            {"ledgebridge",         "Ocean: Whale Artifact"},

            {"stainedglass04",      "Ocean: Vulcano Museum Piece"},

            // Ice
            {"templelowblocker",    "Ice: North East Perimeter Artifact"},
            {"templehighblocker",   "Ice: South Jump Artifact"},
            {"hugelongramp",        "Ice: Outside West Jump Artifact"},
            {"sliderclamp",         "Ice: North East Jump Artifact"},
            {"walkwayblocker",      "Ice: Lowest East Jump Artifact"},
            {"templesimpleblocker", "Ice: South East Tower Artifact"},
            {"longtowerbridge",     "Ice: East Top Jump Artifact"},
            {"triplebridge",        "Ice: South West Tower Artifact"},
            {"templehighramp",      "Ice: North East Tower Artifact"},
            {"bentbridge",          "Ice: South East Tower Jump Artifact"},
            {"templetop",           "Ice: North East Bridge Ramp Artifact"},
            {"treewall",            "Ice: North East Tower Interior Artifact"},

            {"stainedglass09",      "Ice: North East Tower Interior Museum Piece"},

            // Sheep
            {"sheepramp",           "Sheep: West Hidden Behind Tree Artifact"},
            {"sheeppendoor",        "Sheep: In Sheep Shed Artifact"},
            {"windmilldoor",        "Sheep: Sheep Herder Artifact"},
            {"sheeppen",            "Sheep: Inside Windmill Artifact"},
            {"sheephiddendoor",     "Sheep: Raised Shed Artifact"},
            {"unijunk",             "Sheep: Inside Raised Shed Artifact"},

            // Island
            {"seawayblock",         "Island: Spiral Island Artifact"},
            {"underseabridge",      "Island: East Small Rock In Ocean Artifact"},
            {"seawalkway01",        "Island: Artifact Hidden Under East Path"},
            {"plankblocker",        "Island: East Path First Artifact"},
            {"seacornerramp",       "Island: Raft Behind Start Artifact"},
            {"seawalkway02",        "Island: South East Triangle Island Artifact"},
            {"seaarchramp",         "Island: East Path Second Artifact"},
            {"seawalkway03",        "Island: East Path North Raft Artifact"},
            {"timedoor",            "Island: East Path South Raft Artifact"},
            {"searockhill",         "Island: East Path End Artifact"},
            {"seasideramp",         "Island: Shark Island Artifact"},
            {"caveblockerchip",     "Island: West Island Ramp Artifact"},
            {"longsearamp",         "Island: East Island Ledge Artifact"},
            {"seahole",             "Island: South Path Jump Artifact"},
            {"rockholedoor",        "Island: South East Cave Artifact"},
            {"clam",                "Island: South Path Cave Artifact"},
            {"waterpinnacle",       "Island: Clam Artifact"},
            {"leftsearamp",         "Island: West Jump Artifact"},
            {"raftdoorblocker",     "Island: North Wall Lower Artifact"},
            {"rightsearamp",        "Island: East Path Raft Cave Artifact"},
            {"seamonsterhump" ,     "Island: North Wall Upper Artifact"},
            {"raftblocker",         "Island: Back Serpant Hump Artifact"},
            {"seamonsterhead",      "Island: Second South Path Cave Artifact"},
            {"plaque",              "Island: Serpant Head Artifact"},
            {"treeramp",            "Island: Hut Ledge Artifact"},
            {"seamonsterheadramp",  "Island: Night South Path Artifact"},
            {"hutblocker",          "Island: Front Serpant Hump Artifact"},
            {"seablocktop",         "Island: Balcony Hut Artifact"},
            {"huttreeway",          "Island: East Ocean Jump Artifact"},
            {"treeway",             "Island: Treetop Near Flower Artifact"},
            {"treeponddrain",        "Island: Treetop Above Pond Ramp Artifact"},
            {"uppertreeblocker",    "Island: Drained Pond Artifact"},
            {"hutdoor",             "Island: Treetop Inside Flower Artifact"},
            {"islandexitramp",      "Island: Inside Hut Artifact"},
            {"upperdoor",           "Island: Exit Reward Artifact"},

            // Throne
            {"throneleftramp",      "Throne: Behind Throne Artifact"},
            {"thronerightramp",     "Throne: South West Trick Jump Artifact"},
            {"thronewindow01",      "Throne: South East Trick Jump Artifact"},
            {"thronewindow06",      "Throne: North East Window Artifact"},
            {"thronedoorramp",      "Throne: South West Window Artifact"},
            {"thronedoor",          "Throne: South East Window Artifact"},
            {"thronewindow02",      "Throne: Lower Garden Artifact"},
            {"thronerightblocker",  "Throne: Hidden East Garden Artifact"},
            {"throneleftblocker",   "Throne: Hidden West Garden Artifact"},
            {"thronewindow03",      "Throne: Middle West Window Artifact"},
            {"thronewindow04",      "Throne: Middle East Window Artifact"},
            {"thronewindow05",      "Throne: South West Window Artifact"},
            {"thronerightdoor",     "Throne: South East Window Artifact"},
            {"throneleftdoor",      "Throne: East Exterior Wall Artifact"},
            {"throneportalbridge",  "Throne: Exterior Corner Wall Artifact"},
            {"thronebackcover",     "Throne: Upper Garden Artifact"},
            {"throneramp",          "Throne: Hidden Throne Door Artifact"},
            {"throneportalopen",    "Throne: Throne Ramp Artifact"},
            {"threewaywall",        "Throne: Exit Reward Artifact"},

            {"stainedglass08",      "Throne: Brick Bristles' Museum Piece"},

            // Planetarium
            {"planetariumblock",    "Planetarium: Top of Portal Artifact"},
            {"threewallrun",        "Planetarium: Top Path Artifact"},
            {"stainedglass07",      "Planetarium: X Puzzle Museum Piece"},

            // Power Room
            {"greenblocker",        "Power Room: East Bottom Artifact"},
            {"greencable",          "Power Room: Green Center Artifact"},
            {"blueblocker",         "Power Room: Green Cable Artifact"},
            {"bluecable",           "Power Room: Blue Center Artifact"},
            {"redblocker",          "Power Room: Blue Cable Artifact"},
            {"redcable",            "Power Room: Red Center Artifact"},
            {"yellowblocker",       "Power Room: Red Cable Artifact"},
            {"yellowcable",         "Power Room: Yellow Center Artifact"},
            {"yellowbook",          "Power Room: Book Artifac"},
            {"cbb",                 "Power Room: Top Artifact Near Token"},

            // Limbo
            {"yellowcrown",         "limbo: Crown Artifact"},
        };

        public static List<string> disabledSecrets = new List<string>();

        public static string getLocationName(string secretID) {
            if(!locationMapping.ContainsKey(secretID)) {
                return "";
            }

            return locationMapping[secretID];
        }

        public static Dictionary<string, List<string>> getHubSecrets() {
            return hubSecretMapping;
        }

        public static List<string> locToSecretID(string locName) {
            List<string> result = hubSecretMapping[locName];
            if(result != null) {
                return result;
            }

            return new List<string>();
        }

        public static string unlockSecret(string locName, int count) {
            List<string> secretIDs = locToSecretID(locName);

            if(!secretIDs.Any()) {
                CarQuestAP._log.LogError($"{locName} has no secret mapped!");
                return null;
            }

            CarQuestAP._log.LogInfo($"Unlocking {secretIDs[count-1]} ({locName})");
            CarQuestAP.saves[CarQuestAP.saveSlot].AddNewSecret(secretIDs[count - 1]);   
            return secretIDs[count - 1];
        }

        public static bool isDisabled(string secretID) {
            return disabledSecrets.Contains(secretID);
        }
    }
}