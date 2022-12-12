using UnityEngine;
using UImGui;
using ImGuiNET;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private UIWindow window;
    private MapGenerator _mapGenerator;
    private bool _isOpen = false;
    private bool _showAboutWindow = false;


    private void Awake()
    {
        window = GetComponent<UIWindow>();
        UImGuiUtility.Layout += OnLayout;
        UImGuiUtility.OnInitialize += OnInitialize;
        UImGuiUtility.OnDeinitialize += OnDeinitialize;
    }

    private void Update()
    {
        
        // Escape key to exit game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Backtick/backquote key OR double-tap the screen to invoke debug menu
        if (Input.GetKeyDown(KeyCode.BackQuote) || Input.touchCount == 2)
        {
            _isOpen = !_isOpen;
        }

        // Touch inputs
        if (Input.touchCount <= 0)
        {
            return;
        }
    }

    private void OnLayout(UImGui.UImGui obj)
    {
        // Create main window
        if(_isOpen) 
        {
            ImGui.Begin("Tower Defence Menu", ref _isOpen, ImGuiWindowFlags.MenuBar);

            // Menu bar: File, Algorithm select, About
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Exit", "Esc"))
                    {
                        Application.Quit();
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Algorithm"))
                {
                    if (ImGui.MenuItem("Dijkstra's", "1"))
                    {
                        Debug.Log("Dijkstra's algorithm selected");
                    }

                    if (ImGui.MenuItem("A*", "2"))
                    {
                        Debug.Log("A* algorithm selected");
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("About"))
                {
                    if (ImGui.MenuItem("About this program..."))
                    {
                        _showAboutWindow = true;
                    }
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();

                ImGui.TextColored(new Vector4(0, 1, 0, 1), $"Buttons:");
                ImGui.Separator();
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "Left Mouse Button:");
                ImGui.SameLine();
                ImGui.Text("Set Start");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "Right Mouse Button:");
                ImGui.SameLine();
                ImGui.Text("Set Goal");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "Q Button:");
                ImGui.SameLine();
                ImGui.Text("Spawn Plains");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "W Button:");
                ImGui.SameLine();
                ImGui.Text("Spawn Woods");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "E Button:");
                ImGui.SameLine();
                ImGui.Text("Spawn Walls");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "F Button:");
                ImGui.SameLine();
                ImGui.Text("Spawn Minion");
                ImGui.TextColored(new Vector4(1, 1, 0, 1), "Space Bar:");
                ImGui.SameLine();
                ImGui.Text("Show Coords");

            }
            ImGui.End();

            // About window
            if (_showAboutWindow)
            {
                ImGui.Begin("About 3DTowerDefence", ref _showAboutWindow);
                ImGui.Text("Simon Vannarath for TAFENSW Assessment");
                ImGui.Text("Instructor: Andrew Capela");
                if (ImGui.Button("Close"))
                {
                    _showAboutWindow = false;
                }
                ImGui.End();
            }
        }
        

    }

    private void OnInitialize(UImGui.UImGui obj)
    {
        // runs after UImGui.OnEnable();
    }

    private void OnDeinitialize(UImGui.UImGui obj)
    {
        // runs after UImGui.OnDisable();
    }

    private void OnDisable()
    {
        UImGuiUtility.Layout -= OnLayout;
        UImGuiUtility.OnInitialize -= OnInitialize;
        UImGuiUtility.OnDeinitialize -= OnDeinitialize;
    }
}
