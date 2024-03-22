using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Feedback_Activation : MonoBehaviour
{
    #region Booleans
    public bool playerAnimation;
    public bool playerWalkSound;
    public bool playerWalkParticles;
    public bool playerJumpSound;
    public bool playerLandingSound;
    public bool playerLandingParticles;
    public bool gunSound;
    public bool shootingParticles;
    public bool gunRecoil;
    public bool gunHitSound;
    public bool gunHitParticles;
    public bool gunAnimation;
    public bool playerInjurySound;
    public bool playerInjuryRecoil;
    public bool zombieAnimation;
    public bool zombieWalkSound;
    public bool zombieSound;
    public bool bulletHitSound;
    public bool angryZombieSound;
    public bool bloodParticles;
    public bool screenShake;
    #endregion

    #region Toggles 
    public Toggle playerAnimationToggle;
    public Toggle playerWalkSoundToggle;
    public Toggle playerWalkParticlesToggle;
    public Toggle playerJumpSoundToggle;
    public Toggle playerLandingSoundToggle;
    public Toggle playerLandingParticlesToggle;
    public Toggle gunSoundToggle;
    public Toggle shootingParticlesToggle;
    public Toggle gunRecoilToggle;
    public Toggle gunHitSoundToggle;
    public Toggle gunHitParticlesToggle;
    public Toggle gunAnimationToggle;
    public Toggle playerInjurySoundToggle;
    public Toggle playerInjuryRecoilToggle;
    public Toggle zombieAnimationToggle;
    public Toggle zombieWalkSoundToggle;
    public Toggle zombieSoundToggle;
    public Toggle bulletHitSoundToggle;
    public Toggle angryZombieSoundToggle;
    public Toggle bloodParticlesToggle;
    public Toggle landingScreenShakeToggle;
    #endregion

    #region Variables
    public float feedbackElementsClick;
    #endregion

    public GameObject panels;

    private void Update()
    {
        if (feedbackElementsClick % 2 == 1)
        {
            panels.SetActive(true);
        }
        else if (feedbackElementsClick % 2 == 0)
        {
            panels.SetActive(false);
        }

        if (playerAnimationToggle.isOn)
        {
            playerAnimation = true;
        }
        else
        {
            playerAnimation = false;
        }

        if (playerWalkSoundToggle.isOn)
        {
            playerWalkSound = true;
        }
        else
        {
            playerWalkSound = false;
        }

        if (playerWalkParticlesToggle.isOn)
        {
            playerWalkParticles = true;
        }
        else
        {
            playerWalkParticles = false;
        }

        if (playerJumpSoundToggle.isOn)
        {
            playerJumpSound = true;
        }
        else
        {
            playerJumpSound = false;
        }

        if (playerLandingSoundToggle.isOn)
        {
            playerLandingSound = true;
        }
        else
        {
            playerLandingSound = false;
        }

        if (playerLandingParticlesToggle.isOn)
        {
            playerLandingParticles = true;
        }
        else
        {
            playerLandingParticles = false;
        }

        if (gunSoundToggle.isOn)
        {
            gunSound = true;
        }
        else
        {
            gunSound = false;
        }

        if (shootingParticlesToggle.isOn)
        {
            shootingParticles = true;
        }
        else
        {
            shootingParticles = false;
        }

        if (gunRecoilToggle.isOn)
        {
            gunRecoil = true;
        }
        else
        {
            gunRecoil = false;
        }

        if (gunHitSoundToggle.isOn)
        {
            gunHitSound = true;
        }
        else
        {
            gunHitSound = false;
        }

        if (gunHitParticlesToggle.isOn)
        {
            gunHitParticles = true;
        }
        else
        {
            gunHitParticles = false;
        }

        if (gunAnimationToggle.isOn)
        {
            gunAnimation = true;
        }
        else
        {
            gunAnimation = false;
        }

        if (playerInjurySoundToggle.isOn)
        {
            playerInjurySound = true;
        }
        else
        {
            playerInjurySound = false;
        }

        if (playerInjuryRecoilToggle.isOn)
        {
            playerInjuryRecoil = true;
        }
        else
        {
            playerInjuryRecoil = false;
        }

        if (zombieAnimationToggle.isOn)
        {
            zombieAnimation = true;
        }
        else
        {
            zombieAnimation = false;
        }

        if (zombieWalkSoundToggle.isOn)
        {
            zombieWalkSound = true;
        }
        else
        {
            zombieWalkSound = false;
        }

        if (zombieSoundToggle.isOn)
        {
            zombieSound = true;
        }
        else
        {
            zombieSound = false;
        }

        if (bulletHitSoundToggle.isOn)
        {
            bulletHitSound = true;
        }
        else
        {
            bulletHitSound = false;
        }

        if (angryZombieSoundToggle.isOn)
        {
            angryZombieSound = true;
        }
        else
        {
            angryZombieSound = false;
        }

        if (bloodParticlesToggle.isOn)
        {
            bloodParticles = true;
        }
        else
        {
            bloodParticles = false;
        }

        if (landingScreenShakeToggle.isOn)
        {
            screenShake = true;
        }
        else
        {
            screenShake = false;
        }
    }

    public void FeedbackElements()
    {
        feedbackElementsClick += 1;
    }

    public void QuitSimulation()
    {
        Application.Quit();
    }
}
