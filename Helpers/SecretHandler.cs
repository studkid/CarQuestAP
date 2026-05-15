using System.Collections.Generic;

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
            {"Hub: Pool Push Block",                         ["moveableblock"]},
            {"Hub: Pool South East Blocker",                 ["pooltopper1"]},
            {"Hub: Pool North West Blocker",                 ["pooltopper2"]},
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
            {"Hub: Secondary Univery Wall Door",             ["blockramp"]},
            {"Hub: Blocker Near Whale Bridge",               ["raiseblock"]},
            {"Hub: Whale Bridge",                            ["whalebridge"]},
            {"Hub: Colloseum Bridge",                        ["arenabridge"]},
            {"Hub: Colloseum Podeum Extension",              ["arenaextension"]},
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
            {"Hub: Start Outlook Door",                      ["frontledge"]},
            {"Hub: University Doors",                        ["templedoor"]},
            {"Hub: University Back Row Ramp",                ["uniramp"]},
            {"Hub: University Lower Second Row Ramp",        ["unichair"]},
            {"Hub: University Lower Third Row Ramp",         ["unichair2"]},
            {"Hub: University Lower Forth Row Ramp",         ["unichair3"]},
            {"Hub: University Lower Push Ramp",              ["unimovableramp"]},
            {"Hub: University Lower Back Artifact Platform", ["unibackramp"]},
            {"Hub: University Second Floor Ramp",            ["templeramp"]},
            {"Hub: Upper Bridge Jump Walls",                 ["jumpwall"]},
            {"Hub: Tree Area Door",                          ["treewall"]},
            {"Hub: University Portal Buttons",               ["unijunk"]},
            {"Hub: Throne Room Door",                        ["upperdoor"]},
            {"Hub: Power Room South Door",                   ["thronebackcover"]},
            {"Hub: University Portal Planetarium Access",    ["uniportalupgrade"]},
            {"Hub: Power Room North Door",                   ["threewallrun"]},
            {"Hub: World Peace",                             ["brickbristles"]},
        };

        private static Dictionary<string, List<string>>  museumSecretMapping = new Dictionary<string, List<string>>() {
            // Hub Museum
            {"Hub: Sun Museum Glass",                        ["stainedglass01"]},
            {"Hub: Block Museum Glass",                      [""]},
            {"Hub: Book Museum Glass",                       [""]},
            {"Hub: Energy Cell Museum Glass",                [""]},
            {"Hub: Tire Museum Glass",                       [""]},
            {"Hub: Blockstar Museum Glass",                  [""]},
            {"Hub: Tree Museum Glass",                       [""]},
            {"Hub: Cube Museum Glass",                       [""]},
            {"Hub: Portal Museum Glass",                     ["stainedglass07"]},
            {"Hub: Brick Bristles Museum Glass",             [""]},
        };

        private static Dictionary<string, string> locationMapping = new Dictionary<string, string>() {
            //Hub
            {"wall01",               "Hub: Starting Area Artifact"},
            {"poolfardoor",          "Hub: University Alleyway Artifact"},
            {"pieceramptop",         "Hub: North Pool Secret Door Artifact"},
            {"sculpturecover",       "Hub: North Pool Jump Ramp"},
            {"cornerramp",           "Hub: Tree Slalom Start Artifact"},
            {"leftshortwall",        "Hub: Upper University Alleyway Artifact"},
            {"slalomtrees",          "Hub: South Pool Deadend Artifact"},
            {"museumramp",           "Hub: Tree Slalom Reward Artifact"},
            {"sidebridge",           "Hub: Museum Artifact"},
            {"shortwall",            "Hub: Cube Monument Artifact"},
            {"vaultdoor",            "Hub: Ramp Near South Portal Artifact"},
            {"backbridgeramp",       "Hub: North Pool Vault Room Artifact"},
            {"backbridge",           "Hub: Inside Ramp Near South Portal Artifact"},
            {"pool",                 "Hub: Pool Drain Artifact"},
            {"bigwall",              "Hub: Drained Pool Jump Artifact"},
            {"moveableblock",        "Hub: Throne Exterior Near Museum Piece Artifact"},
            {"pooltopper1",          "Hub: Pool South West Artifact"},
            {"pooltopper2",          "Hub: Pool South East Artifact"},
            {"vaultinnerdoor",       "Hub: Pool North West Artifact"},
            {"blockfall",            "Hub: Pool Center Artifact"},
            {"wall02",               "Hub: Throne Exterior Artifact"},
            {"toprightramp",         "Hub: Lookout Artifact"},
            {"chip",                 "Hub: Central Bridge East Ramp Artifact"},
            {"topleftramp",          "Hub: University Exterior Artifact"},
            {"blocktop",             "Hub: Central Bridge West Ramp Artifact"},
            {"distantbridge",        "Hub: Pool North East Artifact"},
            {"narrowbridge",         "Hub: Alley Push Ramp Artifact"},
            {"blockramp",            "Hub: Upper Alley Bridge Near Throne Artifact"},
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
        };

        public static string getLocationName(string secretID) {
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
    }
}