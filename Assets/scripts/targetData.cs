using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if (name == "gedungcb1")
                {
                    TextTargetName.GetComponent<Text>().text = "Gedung CB";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gedungcb"); });
                    TextDescription.GetComponent<Text>().text = "Gedung CB merupakan fasilitas kunci di kampus kami, terutama bagi mahasiswa yang memerlukan akses ke teknologi dan sumber belajar terkini. Gedung ini secara khusus didesain untuk mendukung kegiatan perkuliahan praktik, dengan dominasi ruang laboratorium komputer ";
                }



                //If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "gedungzeta")
                {
                    TextTargetName.GetComponent<Text>().text = "Gedung ZETA";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gedungzeta"); });
                    TextDescription.GetComponent<Text>().text = "Gedung Zeta merupakan fasilitas terbaru yang dimiliki oleh Sekolah Vokasi IPB, yang dilengkapi dengan ruang kelas yang nyaman serta perpustakaan yang dapat diakses oleh mahsiswa dan dosen.";
                }

                if (name == "gymnasium")
                {
                    TextTargetName.GetComponent<Text>().text = "Gymnasium";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gymnasium"); });
                    TextDescription.GetComponent<Text>().text = "Gymnasium merupakan fasilitas olahraga terbaru yang menawarkan ruang serbaguna untuk berbagai aktivitas fisik. Gedung ini dirancang dengan lapangan indoor yang luas, memungkinkan pelaksanaan beragam jenis olahraga seperti basket, voli, dan bulu tangkis.";
                }

                if (name == "gedungca")
                {
                    TextTargetName.GetComponent<Text>().text = "Gedung CA";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gedungca"); });
                    TextDescription.GetComponent<Text>().text = "Gedung CA adalah fasilitas akademik yang menjadi pusat kegiatan perkuliahan teori di kampus. Gedung ini dirancang khusus untuk mendukung proses belajar mengajar yang efektif, dengan ruangan-ruangan yang luas dan nyaman.";
                }

                if (name == "gedungcc")
                {
                    TextTargetName.GetComponent<Text>().text = "Gedung CC";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gedungcc"); });
                    TextDescription.GetComponent<Text>().text = "Gedung CC merupakan pusat administrasi kampus, di mana mahasiswa dan dosen dapat menyelesaikan berbagai keperluan administratif. Gedung ini dilengkapi dengan fasilitas ruangan dosen dan berbagai departemen administratif untuk memudahkan proses akademik dan non-akademik.";
                }

                if (name == "gedungti")
                {
                    TextTargetName.GetComponent<Text>().text = "Gedung Ti";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("gedungti"); });
                    TextDescription.GetComponent<Text>().text = "Gedung TI, atau Gedung Teaching Industry, adalah fasilitas yang dirancang untuk menyelenggarakan praktek simulasi kerja. Di dalam gedung ini, mahasiswa atau peserta pelatihan dapat berlatih keterampilan dan pengetahuan mereka dalam lingkungan yang mirip dengan dunia industri nyata.";
                }
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}