using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC 
{
    public class CoinsManager : IDisposable
    {
        private float _animationSpeed = 10f;
        private LevelObjectView _playerView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _coinsViews;

        public CoinsManager(LevelObjectView playerView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimator) 
        {
            _playerView = playerView;
            _spriteAnimator = spriteAnimator;
            _coinsViews = coinViews;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectView coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView._spriteRender, AnimState.Run, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView) 
        {
            if (_coinsViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView._spriteRender);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }

    

}
