using UnityEngine;
using System.Collections.Generic;

public class SlideManager : MonoBehaviour {

	private List<string> text = new List<string>();
	public KeyCode next;
	public KeyCode prev;
	public TextMesh textMesh;
	public Light light;
	public List<Color> colors = new List<Color>();
	Color color = Color.white;
	int i = 0;

	// Use this for initialization
	void Start () {
		text.Add("GET GROOVY GAME GIFS\nCale Bradbury\n@netgrind\nnetgrind.net\ncamp-cult.com");
		text.Add("'gif' vs 'jif'");
		text.Add("who the hell cares\njust look at these visuals");
		text.Add("HOW GIFS WORK");
		text.Add("series of frames\neach frame has a delay");
		text.Add("256 colors per frame\nusually 256 per gif to save size");
		text.Add("1 bit alpha");
		text.Add("LZW encoding\nsearches for patterns\nreplaces with pointers");
		text.Add("WEBSITE GIF LIMITS");
		text.Add("TUMBLR\n2mb\n500px wide, 700px tall");
		text.Add("TWITTER\n3mb\nlooping only\nany dimension\ngets converted into html5 video");
		text.Add("END\nlets go make some rad gifs!");
		
		if(textMesh==null)textMesh = GetComponent<TextMesh>();
		showText();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(next)){
			i++;
			i %=(text.Count);
			showText();
		}else if(Input.GetKeyDown(prev)){
			i--;
			i+=text.Count;
			i %=(text.Count);
			showText();
		}
		light.color = Color.Lerp(light.color,color,.1f);
	}

	void showText(){
		textMesh.text = text[i];
		color = colors[i%colors.Count];
	}
}
